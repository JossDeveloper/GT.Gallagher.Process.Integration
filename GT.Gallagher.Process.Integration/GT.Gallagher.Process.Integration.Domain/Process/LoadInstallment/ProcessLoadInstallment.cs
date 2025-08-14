using GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadInstallment;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;

public class ProcessLoadInstallment : Entity
{
    public string PolicyChannelCode { get; private set; }
    public string InstallmentNumber { get; private set; }
    public string InstallmentStatus { get; private set; }
    public string EmissionDate { get; private set; }
    public string? ExpirationDate { get; private set; }
    public string? CoverageStartDate { get; private set; }
    public string? CoverageEndDate { get; private set; }
    public string? PaymentDate { get; private set; }
    public string InstallmentNetPremium { get; private set; }
    public string? EmissionRight { get; private set; }
    public string InstallmentTotalPremium { get; private set; }
    public string? LqCpNumber { get; private set; }
    public string? OperationNumber { get; private set; }
    public string? InvoiceNumber { get; private set; }
    public string? RejectionReason { get; private set; }
    public string? Attach { get; private set; }

    public ProcessLoadInstallment(string policyChannelCode, string installmentNumber, string installmentStatus, string emissionDate, string? expirationDate, string? coverageStartDate, string? coverageEndDate, string? paymentDate, string installmentNetPremium, string? emissionRight, string installmentTotalPremium, string? lqCpNumber, string? operationNumber, string? invoiceNumber, string? rejectionReason, string? attach)
    {
        PolicyChannelCode = policyChannelCode;
        InstallmentNumber = installmentNumber;
        InstallmentStatus = installmentStatus;
        EmissionDate = emissionDate;
        ExpirationDate = expirationDate;
        CoverageStartDate = coverageStartDate;
        CoverageEndDate = coverageEndDate;
        PaymentDate = paymentDate;
        InstallmentNetPremium = installmentNetPremium;
        EmissionRight = emissionRight;
        InstallmentTotalPremium = installmentTotalPremium;
        LqCpNumber = lqCpNumber;
        OperationNumber = operationNumber;
        InvoiceNumber = invoiceNumber;
        RejectionReason = rejectionReason;
        Attach = attach;

        Validate(this, new ProcessLoadInstallmentValidator());
    }
}
