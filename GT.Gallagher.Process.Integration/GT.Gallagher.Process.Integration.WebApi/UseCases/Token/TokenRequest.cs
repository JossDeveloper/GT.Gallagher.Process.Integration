using System.ComponentModel.DataAnnotations;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Token;

public class TokenRequest
{
    [Required(ErrorMessage = "El Usuario no puede ser nulo y/o vacío")]
    [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.", MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo es permitido letras y números")]
    public string Username { get; set; }

    [Required(ErrorMessage = "El Password no puede ser nulo y/o vacío")]
    [StringLength(200, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.", MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z0-9\@\.\-]+$", ErrorMessage = "Solo es permitido letras, números, guiones, @ y puntos.")]
    public string Password { get; set; }
}


