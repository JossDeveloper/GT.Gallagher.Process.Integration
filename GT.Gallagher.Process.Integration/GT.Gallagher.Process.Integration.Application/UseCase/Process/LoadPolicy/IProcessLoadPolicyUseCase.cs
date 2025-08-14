namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy;

public interface IProcessLoadPolicyUseCase
{
    Task Execute(ProcessLoadPolicyRequest request);
}
