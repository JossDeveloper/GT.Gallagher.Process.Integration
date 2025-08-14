using System.ComponentModel.DataAnnotations;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadVehicle;

public class ProcessLoadVehicleRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public Guid ProcessCode { get; set; }
    [Required]
    public Guid UniqueName { get; set; }
    [Required]
    public IFormFile File { get; set; }
}
