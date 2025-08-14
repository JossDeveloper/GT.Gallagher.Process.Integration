namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInstallment;

public class ProcessLoadInstallment
{
    public string PolicyChannelCode { get; set; }
    public string InstallmentNumber { get; set; }
    public string InstallmentStatus { get; set; }
    public string EmissionDate { get; set; }
    public string? ExpirationDate { get; set; }
    public string? CoverageStartDate { get; set; }
    public string? CoverageEndDate { get; set; }
    public string? PaymentDate { get; set; }
    public string InstallmentNetPremium { get; set; }
    public string? EmissionRight { get; set; }
    public string InstallmentTotalPremium { get; set; }
    public string? LqCpNumber { get; set; }
    public string? OperationNumber { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? RejectionReason { get; set; }
    public string? Attach { get; set; }
}
