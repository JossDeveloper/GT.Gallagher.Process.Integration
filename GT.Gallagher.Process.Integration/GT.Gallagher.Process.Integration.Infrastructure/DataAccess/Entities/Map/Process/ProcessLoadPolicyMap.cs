using CsvHelper.Configuration;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadPolicyMap : ClassMap<ProcessLoadPolicy>
{
    public ProcessLoadPolicyMap()
    {
        Map(m => m.PolicyChannelCode).Index(0);
        Map(m => m.ProcessType).Index(1);
        Map(m => m.ProcessSubType).Index(2);
        Map(m => m.ChannelCode).Index(3);
        Map(m => m.ChannelAgencyCode).Index(4);
        Map(m => m.GallagherAgencyCode).Index(5);
        Map(m => m.ChannelFunctionaryCode).Index(6);
        Map(m => m.GallagherFunctionaryCode).Index(7);
        Map(m => m.MatrixPolicyNumber).Index(8);
        Map(m => m.PreviousPolicyNumber).Index(9);
        Map(m => m.RenewedPolicyNumber).Index(10);
        Map(m => m.TransactionNumber).Index(11);
        Map(m => m.Product).Index(12);
        Map(m => m.Plan).Index(13);
        Map(m => m.Dealer).Index(14);
        Map(m => m.ContractNumber).Index(15);
        Map(m => m.EndorsementNumber).Index(16);
        Map(m => m.OperationNumber).Index(17);
        Map(m => m.PolicyType).Index(18);
        Map(m => m.ContractorCode).Index(19);
        Map(m => m.InsuredCode).Index(20);
        Map(m => m.ResponsiblePaymentCode).Index(21);
        Map(m => m.InvoicedTo).Index(22);
        Map(m => m.MarkEndorsed).Index(23);
        Map(m => m.Endorsee).Index(24);
        Map(m => m.ApplicationDate).Index(25);
        Map(m => m.CiaEmissionDate).Index(26);
        Map(m => m.EffectiveStartDate).Index(27);
        Map(m => m.EffectiveEndDate).Index(28);
        Map(m => m.EmissionRightType).Index(29);
        Map(m => m.EmissionRightPercent).Index(30);
        Map(m => m.EmissionRightValue).Index(31);
        Map(m => m.PaymentMethod).Index(32);
        Map(m => m.InstallmentNumber).Index(33);
        Map(m => m.PolicyStatus).Index(34);
        Map(m => m.NullificationReason).Index(35);
        Map(m => m.Gloss).Index(36);
        Map(m => m.SumInsured).Index(37);
        Map(m => m.NetPremium).Index(38);
        Map(m => m.EmissionRight).Index(39);
        Map(m => m.ChannelCommission).Index(40);
        Map(m => m.BrokerCommission).Index(41);
        Map(m => m.GrossUp).Index(42);
        Map(m => m.MarkApprovalManagement).Index(43);
        Map(m => m.TotalPremium).Index(44);
        Map(m => m.PolicyCommissionStatus).Index(45);
        Map(m => m.Broker).Index(46);
    }
}
