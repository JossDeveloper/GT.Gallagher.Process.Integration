using Dapper;
using FluentValidation.Results;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Common;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Notification;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadClient;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInstallment;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInsured;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadMovement;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadPolicy;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadVehicle;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess;

public class Context : DbContext
{
    public DbSet<ProblemDetail> ProblemDetail { get; set; }
    public DbSet<NotificationEndProcess> NotificationEndProcess { get; set; }
    public DbSet<ScheduledProcesses> ScheduledProcesses { get; set; }
    public DbSet<RepositoryServer> RepositoryServer { get; set; }
    public DbSet<MasterDetailsOutput> MasterDetailsOutput { get; set; }
    public DbSet<ProcessLoadClientFeedBack> ProcessLoadClientFeedBack { get; set; }
    public DbSet<ProcessLoadInstallmentFeedBack> ProcessLoadInstallmentFeedBack { get; set; }
    public DbSet<ProcessLoadInsuredFeedBack> ProcessLoadInsuredFeedBack { get; set; }
    public DbSet<ProcessLoadMovementFeedBack> ProcessLoadMovementFeedBack { get; set; }
    public DbSet<ProcessLoadPolicyFeedBack> ProcessLoadPolicyFeedBack { get; set; }
    public DbSet<ProcessLoadVehicleFeedBack> ProcessLoadVehicleFeedBack { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Environment.GetEnvironmentVariable("DB_CONN") != null)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONN"), sqlServerOptionsAction: option =>
            {
                option.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null);
                option.CommandTimeout(int.Parse(Environment.GetEnvironmentVariable("DB_TIMEOUT_IN_SECONDS")));
            });
        }
        else
        {
            optionsBuilder.UseInMemoryDatabase("GallagherProcessInMemory");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.ApplyConfiguration(new ProblemDetailMap());
        modelBuilder.ApplyConfiguration(new NotificationEndProcessMap());
        modelBuilder.ApplyConfiguration(new ScheduledProcessesMap());
        modelBuilder.ApplyConfiguration(new RepositoryServerMap());
        modelBuilder.ApplyConfiguration(new MasterDetailsOutputMap());
        modelBuilder.ApplyConfiguration(new ProcessLoadClientFeedBackMap());
        modelBuilder.ApplyConfiguration(new ProcessLoadInstallmentFeedBackMap());
        modelBuilder.ApplyConfiguration(new ProcessLoadInsuredFeedBackMap());
        modelBuilder.ApplyConfiguration(new ProcessLoadMovementFeedBackMap());
        modelBuilder.ApplyConfiguration(new ProcessLoadPolicyFeedBackMap());
        modelBuilder.ApplyConfiguration(new ProcessLoadVehicleFeedBackMap());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<List<object>[]> ExecuteDapperQueryMultipleAsync(string sql, object parameters = null, params Type[] entityTypes)
    {
        using (var connection = new SqlConnection(Database.GetDbConnection().ConnectionString))
        {
            connection.Open();

            using (var result = await connection.QueryMultipleAsync(sql, parameters))
            {
                var results = new List<object>[entityTypes.Length];

                for (int i = 0; i < entityTypes.Length; i++)
                {
                    results[i] = result.Read(entityTypes[i]).Cast<object>().ToList();
                }
                return results;
            }
        }
    }
}

