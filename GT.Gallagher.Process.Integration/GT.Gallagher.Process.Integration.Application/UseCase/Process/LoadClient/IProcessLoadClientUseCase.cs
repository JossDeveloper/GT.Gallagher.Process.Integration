namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient;

public interface IProcessLoadClientUseCase
{
    Task Execute(ProcessLoadClientRequest request);
}
