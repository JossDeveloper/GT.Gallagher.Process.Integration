namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment;

public interface IProcessLoadInstallmentUseCase
{
    Task Execute(ProcessLoadInstallmentRequest request);
}
