namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured;

public interface IProcessLoadInsuredUseCase
{
    Task Execute(ProcessLoadInsuredRequest request);
}
