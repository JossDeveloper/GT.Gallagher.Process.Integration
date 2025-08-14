using System.ComponentModel.DataAnnotations;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Recurrent.ProcessPlot;

public class RecurrentPlotRequest
{
    [Required]
    public int UserId { get; set; }
    public int ProcessId { get; set; }
}
