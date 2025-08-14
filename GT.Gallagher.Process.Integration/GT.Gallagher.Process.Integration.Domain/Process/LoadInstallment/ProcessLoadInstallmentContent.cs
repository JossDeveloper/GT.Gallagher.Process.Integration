namespace GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;

public class ProcessLoadInstallmentContent
{
    public int RowNumber { get; private set; }
    public ProcessLoadInstallment ProcessLoadInstallment { get; private set; }

    public ProcessLoadInstallmentContent(int rowNumber, ProcessLoadInstallment processLoadInstallment)
    {
        RowNumber = rowNumber;
        ProcessLoadInstallment = processLoadInstallment;
    }
}
