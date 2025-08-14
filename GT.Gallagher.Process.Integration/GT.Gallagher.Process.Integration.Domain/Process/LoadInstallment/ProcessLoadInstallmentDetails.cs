using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;

public class ProcessLoadInstallmentDetails
{
    public int RowNumber { get; private set; }
    public ProcessLoadInstallment ProcessLoadInstallment { get; private set; }
    public List<ProblemDetail> Details { get; private set; } = new();

    public ProcessLoadInstallmentDetails(int rowNumber, ProcessLoadInstallment processLoadInstallment, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        ProcessLoadInstallment = processLoadInstallment;
        Details = details;
    }

    public ProcessLoadInstallmentDetails(int rowNumber, ProcessLoadInstallment processLoadInstallment, ProblemDetail detail)
    {
        RowNumber = rowNumber;
        ProcessLoadInstallment = processLoadInstallment;
        Details.Add(detail);
    }
}
