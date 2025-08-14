using CsvHelper.Configuration;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInstallment;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadInstallmentMap : ClassMap<ProcessLoadInstallment>
{
    public ProcessLoadInstallmentMap()
    {
        Map(m => m.PolicyChannelCode).Index(0);
        Map(m => m.InstallmentNumber).Index(1);
        Map(m => m.InstallmentStatus).Index(2);
        Map(m => m.EmissionDate).Index(3);
        Map(m => m.ExpirationDate).Index(4);
        Map(m => m.CoverageStartDate).Index(5);
        Map(m => m.CoverageEndDate).Index(6);
        Map(m => m.PaymentDate).Index(7);
        Map(m => m.InstallmentNetPremium).Index(8);
        Map(m => m.EmissionRight).Index(9);
        Map(m => m.InstallmentTotalPremium).Index(10);
        Map(m => m.LqCpNumber).Index(11);
        Map(m => m.OperationNumber).Index(12);
        Map(m => m.InvoiceNumber).Index(13);
        Map(m => m.RejectionReason).Index(14);
        Map(m => m.Attach).Index(15);
    }
}
