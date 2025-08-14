namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement;

public interface IProcessLoadMovementUseCase
{
    Task Execute(ProcessLoadMovementRequest request);
}
