using GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;

public class ProcessLoadPolicy : Entity
{
    public string PolicyChannelCode { get; private set; }
    public string ProcessType { get; private set; }
    public string ProcessSubType { get; private set; }
    public string ChannelCode { get; private set; }
    public string ChannelAgencyCode { get; private set; }
    public string GallagherAgencyCode { get; private set; }
    public string ChannelFunctionaryCode { get; private set; }
    public string GallagherFunctionaryCode { get; private set; }
    public string MatrixPolicyNumber { get; private set; }
    public string PreviousPolicyNumber { get; private set; }
    public string RenewedPolicyNumber { get; private set; }
    public string TransactionNumber { get; private set; }
    public string Product { get; private set; }
    public string Plan { get; private set; }
    public string Dealer { get; private set; }
    public string ContractNumber { get; private set; }
    public string EndorsementNumber { get; private set; }
    public string OperationNumber { get; private set; }
    public string PolicyType { get; private set; }
    public string ContractorCode { get; private set; }
    public string InsuredCode { get; private set; }
    public string ResponsiblePaymentCode { get; private set; }
    public string InvoicedTo { get; private set; }
    public string MarkEndorsed { get; private set; }
    public string Endorsee { get; private set; }
    public string ApplicationDate { get; private set; }
    public string CiaEmissionDate { get; private set; }
    public string EffectiveStartDate { get; private set; }
    public string EffectiveEndDate { get; private set; }
    public string EmissionRightType { get; private set; }
    public string EmissionRightPercent { get; private set; }
    public string EmissionRightValue { get; private set; }
    public string PaymentMethod { get; private set; }
    public string InstallmentNumber { get; private set; }
    public string PolicyStatus { get; private set; }
    public string NullificationReason { get; private set; }
    public string Gloss { get; private set; }
    public string SumInsured { get; private set; }
    public string NetPremium { get; private set; }
    public string EmissionRight { get; private set; }
    public string ChannelCommission { get; private set; }
    public string BrokerCommission { get; private set; }
    public string GrossUp { get; private set; }
    public string MarkApprovalManagement { get; private set; }
    public string TotalPremium { get; private set; }
    public string PolicyCommissionStatus { get; private set; }
    public string Broker { get; private set; }

    public ProcessLoadPolicy(string policyChannelCode, string processType, string processSubType, string channelCode, string channelAgencyCode, string gallagherAgencyCode, string channelFunctionaryCode, string gallagherFunctionaryCode, string matrixPolicyNumber, string previousPolicyNumber, string renewedPolicyNumber, string transactionNumber, string product, string plan, string dealer, string contractNumber, string endorsementNumber, string operationNumber, string policyType, string contractorCode, string insuredCode, string responsiblePaymentCode, string invoicedTo, string markEndorsed, string endorsee, string applicationDate, string ciaEmissionDate, string effectiveStartDate, string effectiveEndDate, string emissionRightType, string emissionRightPercent, string emissionRightValue, string paymentMethod, string installmentNumber, string policyStatus, string nullificationReason, string gloss, string sumInsured, string netPremium, string emissionRight, string channelCommission, string brokerCommission, string grossUp, string markApprovalManagement, string totalPremium, string policyCommissionStatus, string broker)
    {
        PolicyChannelCode = policyChannelCode;
        ProcessType = processType;
        ProcessSubType = processSubType;
        ChannelCode = channelCode;
        ChannelAgencyCode = channelAgencyCode;
        GallagherAgencyCode = gallagherAgencyCode;
        ChannelFunctionaryCode = channelFunctionaryCode;
        GallagherFunctionaryCode = gallagherFunctionaryCode;
        MatrixPolicyNumber = matrixPolicyNumber;
        PreviousPolicyNumber = previousPolicyNumber;
        RenewedPolicyNumber = renewedPolicyNumber;
        TransactionNumber = transactionNumber;
        Product = product;
        Plan = plan;
        Dealer = dealer;
        ContractNumber = contractNumber;
        EndorsementNumber = endorsementNumber;
        OperationNumber = operationNumber;
        PolicyType = policyType;
        ContractorCode = contractorCode;
        InsuredCode = insuredCode;
        ResponsiblePaymentCode = responsiblePaymentCode;
        InvoicedTo = invoicedTo;
        MarkEndorsed = markEndorsed;
        Endorsee = endorsee;
        ApplicationDate = applicationDate;
        CiaEmissionDate = ciaEmissionDate;
        EffectiveStartDate = effectiveStartDate;
        EffectiveEndDate = effectiveEndDate;
        EmissionRightType = emissionRightType;
        EmissionRightPercent = emissionRightPercent;
        EmissionRightValue = emissionRightValue;
        PaymentMethod = paymentMethod;
        InstallmentNumber = installmentNumber;
        PolicyStatus = policyStatus;
        NullificationReason = nullificationReason;
        Gloss = gloss;
        SumInsured = sumInsured;
        NetPremium = netPremium;
        EmissionRight = emissionRight;
        ChannelCommission = channelCommission;
        BrokerCommission = brokerCommission;
        GrossUp = grossUp;
        MarkApprovalManagement = markApprovalManagement;
        TotalPremium = totalPremium;
        PolicyCommissionStatus = policyCommissionStatus;
        Broker = broker;

        Validate(this, new ProcessLoadPolicyValidator());
    }
}
