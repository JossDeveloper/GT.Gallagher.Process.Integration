using GT.Gallagher.Process.Integration.WebApi.UseCases.Recurrent.ProcessPlot;
using Hangfire;

namespace GT.Gallagher.Process.Integration.WebApi.Jobs;

public class RecurringJobs
{
    public static void ConfigureRecurringJobs()
    {
        //https://www.freeformatter.com/cron-expression-generator-quartz.html => For expression
        //https://crontab.cronhub.io/ => Understand expression

        RecurrentPlotRequest requestProcessClient = new RecurrentPlotRequest() { UserId = 1, ProcessId = 606 };
        RecurrentPlotRequest requestProcessPolicy = new RecurrentPlotRequest() { UserId = 1, ProcessId = 739 };
        RecurrentPlotRequest requestProcessVehicle = new RecurrentPlotRequest() { UserId = 1, ProcessId = 740 };
        RecurrentPlotRequest requestProcessInstallment = new RecurrentPlotRequest() { UserId = 1, ProcessId = 889};
        RecurrentPlotRequest requestProcessInsured = new RecurrentPlotRequest() { UserId = 1, ProcessId = 890 };
        RecurrentPlotRequest requestProcessMovement = new RecurrentPlotRequest() { UserId = 1, ProcessId = 891 };

        RecurringJob.AddOrUpdate<RecurrentController>("ProcessPlot-Clientes", (s) => s.ProcessPlot(requestProcessClient), Environment.GetEnvironmentVariable("CRON_TIME_PROCESS_CLIENT"));
        RecurringJob.AddOrUpdate<RecurrentController>("ProcessPlot-Polizas", (s) => s.ProcessPlot(requestProcessPolicy), Environment.GetEnvironmentVariable("CRON_TIME_PROCESS_POLICY"));
        RecurringJob.AddOrUpdate<RecurrentController>("ProcessPlot-Riesgos", (s) => s.ProcessPlot(requestProcessVehicle), Environment.GetEnvironmentVariable("CRON_TIME_PROCESS_VEHICLE"));
        RecurringJob.AddOrUpdate<RecurrentController>("ProcessPlot-Cuotas", (s) => s.ProcessPlot(requestProcessInstallment), Environment.GetEnvironmentVariable("CRON_TIME_PROCESS_INSTALLMENT"));
        RecurringJob.AddOrUpdate<RecurrentController>("ProcessPlot-Asegurados", (s) => s.ProcessPlot(requestProcessInsured), Environment.GetEnvironmentVariable("CRON_TIME_PROCESS_INSURED"));
        RecurringJob.AddOrUpdate<RecurrentController>("ProcessPlot-Movimientos", (s) => s.ProcessPlot(requestProcessMovement), Environment.GetEnvironmentVariable("CRON_TIME_PROCESS_MOVEMENT"));

    }
}
