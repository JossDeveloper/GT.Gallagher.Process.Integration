using CsvHelper.Configuration;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadVehicleMap : ClassMap<ProcessLoadVehicle>
{
    public ProcessLoadVehicleMap()
    {
        Map(m => m.PolicyChannelCode).Index(0);
        Map(m => m.VehicleChannelCode).Index(1);
        Map(m => m.CertificateNumber).Index(2);
        Map(m => m.CommercialValue).Index(3);
        Map(m => m.CommercialValueWeighted).Index(4);
        Map(m => m.ClientRate).Index(5);
        Map(m => m.CiaRate).Index(6);
        Map(m => m.ClientNetPremium).Index(7);
        Map(m => m.ClientEmissionRight).Index(8);
        Map(m => m.ClientTotalPremium).Index(9);
        Map(m => m.CiaNetPremium).Index(10);
        Map(m => m.CiaEmissionRight).Index(11);
        Map(m => m.CiaTotalPremium).Index(12);
        Map(m => m.ChannelCommissionRate).Index(13);
        Map(m => m.BrokerCommissionRate).Index(14);
        Map(m => m.GrossUp).Index(15);
        Map(m => m.Coverage).Index(16);
        Map(m => m.UseVehicle).Index(17);
        Map(m => m.Plaque).Index(18);
        Map(m => m.ClassVehicle).Index(19);
        Map(m => m.TypeVehicle).Index(20);
        Map(m => m.Brand).Index(21);
        Map(m => m.Model).Index(22);
        Map(m => m.Version).Index(23);
        Map(m => m.SerialNumber).Index(24);
        Map(m => m.EngineNumber).Index(25);
        Map(m => m.Seats).Index(26);
        Map(m => m.Antique).Index(27);
        Map(m => m.ManufactureYear).Index(28);
        Map(m => m.Zone).Index(29);
        Map(m => m.CertificateStartDate).Index(30);
        Map(m => m.CertificateEndDate).Index(31);
        Map(m => m.ExclusionDate).Index(32);
        Map(m => m.TractPlaque).Index(33);
        Map(m => m.MarkSinkholeUse).Index(34);
        Map(m => m.MarkOptionalUse).Index(35);
        Map(m => m.MarkApprovalManagement).Index(36);
        Map(m => m.CertificateStatus).Index(37);
        Map(m => m.InactivityReason).Index(38);
        Map(m => m.ModalityDescription).Index(39);
    }
}
