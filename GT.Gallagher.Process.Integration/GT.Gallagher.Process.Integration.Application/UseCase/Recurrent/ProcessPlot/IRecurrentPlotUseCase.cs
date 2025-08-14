namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot;

public interface IRecurrentPlotUseCase
{
    Task Execute(RecurrentPlotRequest request);
}
