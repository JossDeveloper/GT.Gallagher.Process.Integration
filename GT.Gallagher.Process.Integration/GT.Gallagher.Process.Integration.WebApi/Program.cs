using Autofac;
using Autofac.Extensions.DependencyInjection;
using GlobalTpa.Extension.Serilog.Implementation;
using GlobalTpa.Extension.Startup.WebApi.DependencyInjection;
using GlobalTpa.Extension.Startup.WebApi.Resources;
using GT.Gallagher.Process.Integration.WebApi.DependencyInjection;
using GT.Gallagher.Process.Integration.WebApi.Jobs;
using GT.Gallagher.Process.Integration.WebApi.Pipeline;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Converters;
using Serilog;
using System.Text.Json.Serialization;

Log.Logger = new Logger().ConfigureLogger();
Log.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.UseSerilog();
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddAutofacRegistration());

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddJwtToken();
builder.Services.AddLocalization();
builder.Services.AddVersioning();
builder.Services.AddProblemDetails();
builder.Services.AddFilters();
builder.Services.Cors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Swagger();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
     );

builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddHangfire(
    c => c.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(Environment.GetEnvironmentVariable("DB_CONN")));
builder.Services.AddHangfireServer();

var app = builder.Build();
var resources = ((IApplicationBuilder)app).ApplicationServices.GetService<IStringLocalizer<ReturnMessages>>();
var env = app.Services.GetRequiredService<IWebHostEnvironment>();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new ErrorHandlerMiddleware(env, resources).Invoke
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), $@"{Environment.GetEnvironmentVariable("LOCAL_FILE_PROVIDER")}")),
        RequestPath = new PathString($"{Environment.GetEnvironmentVariable("LOCAL_REQUEST_PATH")}")
    });
    app.UseSwaggerUI(s =>
    {
        s.DocumentTitle = Environment.GetEnvironmentVariable("SWAGGER_TITLE");
        s.InjectStylesheet($"{Environment.GetEnvironmentVariable("LOCAL_STYLE_SHEET")}");
        s.InjectJavascript($"{Environment.GetEnvironmentVariable("LOCAL_JAVA_SCRIPT")}", "text/javascript");
    });
}

if (app.Environment.IsDevelopment())
    app.UseHangfireDashboard(options: new DashboardOptions
    {
        Authorization = new[] {
            new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions{
                RequireSsl = true,
                SslRedirect = true,
                LoginCaseSensitive = true,
                Users = new []
                {
                    new BasicAuthAuthorizationUser
                    {
                        Login = Environment.GetEnvironmentVariable("USER"),
                        PasswordClear = Environment.GetEnvironmentVariable("PASS")
                    }
                }}) },
        IsReadOnlyFunc = (context) => bool.TryParse(Environment.GetEnvironmentVariable("HANGFIRE_READONLY"), out var result) && result, //For readonly
        DashboardTitle = Environment.GetEnvironmentVariable("HANGFIRE_DASHBOARD_TITLE"),
        FaviconPath = new PathString(Environment.GetEnvironmentVariable("HANGFIRE_DASHBOARD_ICON"))
    });

RecurringJobs.ConfigureRecurringJobs();

app.UseHangfireServer();

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.AddLocalization();
app.UseHttpsRedirection();
app.UseCors();
app.UseProblemDetails();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(e => e.MapControllers());
app.AddOptions();

app.Run();
