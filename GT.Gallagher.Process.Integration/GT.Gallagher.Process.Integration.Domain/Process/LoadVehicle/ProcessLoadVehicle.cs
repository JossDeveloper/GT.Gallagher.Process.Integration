using GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

public class ProcessLoadVehicle : Entity
{
    public string PolicyChannelCode { get; private set; }
    public string VehicleChannelCode { get; private set; }
    public string CertificateNumber { get; private set; }
    public string CommercialValue { get; private set; }
    public string CommercialValueWeighted { get; private set; }
    public string ClientRate { get; private set; }
    public string CiaRate { get; private set; }
    public string ClientNetPremium { get; private set; }
    public string ClientEmissionRight { get; private set; }
    public string ClientTotalPremium { get; private set; }
    public string CiaNetPremium { get; private set; }
    public string CiaEmissionRight { get; private set; }
    public string CiaTotalPremium { get; private set; }
    public string ChannelCommissionRate { get; private set; }
    public string BrokerCommissionRate { get; private set; }
    public string GrossUp { get; private set; }
    public string Coverage { get; private set; }
    public string UseVehicle { get; private set; }
    public string Plaque { get; private set; }
    public string ClassVehicle { get; private set; }
    public string TypeVehicle { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Version { get; private set; }
    public string SerialNumber { get; private set; }
    public string EngineNumber { get; private set; }
    public string Seats { get; private set; }
    public string Antique { get; private set; }
    public string ManufactureYear { get; private set; }
    public string Zone { get; private set; }
    public string CertificateStartDate { get; private set; }
    public string CertificateEndDate { get; private set; }
    public string ExclusionDate { get; private set; }
    public string TractPlaque { get; private set; }
    public string MarkSinkholeUse { get; private set; }
    public string MarkOptionalUse { get; private set; }
    public string MarkApprovalManagement { get; private set; }
    public string CertificateStatus { get; private set; }
    public string InactivityReason { get; private set; }
    public string ModalityDescription { get; private set; }

    public ProcessLoadVehicle(string policyChannelCode, string vehicleChannelCode, string certificateNumber, string commercialValue, string commercialValueWeighted, string clientRate, string ciaRate, string clientNetPremium, string clientEmissionRight, string clientTotalPremium, string ciaNetPremium, string ciaEmissionRight, string ciaTotalPremium, string channelCommissionRate, string brokerCommissionRate, string grossUp, string coverage, string useVehicle, string plaque, string classVehicle, string typeVehicle, string brand, string model, string version, string serialNumber, string engineNumber, string seats, string antique, string manufactureYear, string zone, string certificateStartDate, string certificateEndDate, string exclusionDate, string tractPlaque, string markSinkholeUse, string markOptionalUse, string markApprovalManagement, string certificateStatus, string inactivityReason, string modalityDescription)
    {
        PolicyChannelCode = policyChannelCode;
        VehicleChannelCode = vehicleChannelCode;
        CertificateNumber = certificateNumber;
        CommercialValue = commercialValue;
        CommercialValueWeighted = commercialValueWeighted;
        ClientRate = clientRate;
        CiaRate = ciaRate;
        ClientNetPremium = clientNetPremium;
        ClientEmissionRight = clientEmissionRight;
        ClientTotalPremium = clientTotalPremium;
        CiaNetPremium = ciaNetPremium;
        CiaEmissionRight = ciaEmissionRight;
        CiaTotalPremium = ciaTotalPremium;
        ChannelCommissionRate = channelCommissionRate;
        BrokerCommissionRate = brokerCommissionRate;
        GrossUp = grossUp;
        Coverage = coverage;
        UseVehicle = useVehicle;
        Plaque = plaque;
        ClassVehicle = classVehicle;
        TypeVehicle = typeVehicle;
        Brand = brand;
        Model = model;
        Version = version;
        SerialNumber = serialNumber;
        EngineNumber = engineNumber;
        Seats = seats;
        Antique = antique;
        ManufactureYear = manufactureYear;
        Zone = zone;
        CertificateStartDate = certificateStartDate;
        CertificateEndDate = certificateEndDate;
        ExclusionDate = exclusionDate;
        TractPlaque = tractPlaque;
        MarkSinkholeUse = markSinkholeUse;
        MarkOptionalUse = markOptionalUse;
        MarkApprovalManagement = markApprovalManagement;
        CertificateStatus = certificateStatus;
        InactivityReason = inactivityReason;
        ModalityDescription = modalityDescription;

        Validate(this, new ProcessLoadVehicleValidator());
    }
}
