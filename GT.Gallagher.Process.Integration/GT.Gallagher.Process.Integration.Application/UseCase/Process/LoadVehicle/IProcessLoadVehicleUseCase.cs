namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle;

public interface IProcessLoadVehicleUseCase
{
    Task Execute(ProcessLoadVehicleRequest request);
}
