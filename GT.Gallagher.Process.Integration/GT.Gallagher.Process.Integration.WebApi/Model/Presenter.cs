using GlobalTpa.Extension.Startup.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GT.Gallagher.Process.Integration.WebApi.Model;

public abstract class Presenter
{
    public IActionResult ViewModel { get; protected set; }

    public virtual void Error(List<Domain.Base.ValidationFailure> details)
    {
        var problemDetails = new ProblemDetailsBadRequest()
        {
            Type = "Bad Request",
            Status = StatusCodes.Status400BadRequest,
            Title = "Un error ocurrió en el request.",
            Details = details.Select(s => new ProblemDetail($"Campo {s.PropertyName} inválido", s.ErrorMessage)).ToList()
        };

        ViewModel = new BadRequestObjectResult(problemDetails);
    }

    public virtual void Error(List<Domain.Base.ProblemDetail> details)
    {
        var problemDetails = new ProblemDetailsBadRequest()
        {
            Type = "Bad Request",
            Status = StatusCodes.Status400BadRequest,
            Title = "Un error ocurrió en el request.",
            Details = details.Select(s => new ProblemDetail(s.Title, s.Message)).ToList()
        };

        ViewModel = new BadRequestObjectResult(problemDetails);
    }

    public virtual void ErrorServer(string message)
    {
        var problemDetails = new ProblemDetailsOtherRequest()
        {
            Title = message,
            Status = StatusCodes.Status500InternalServerError,
            Type = "Error Server"
        };

        ViewModel = new ObjectResult(problemDetails)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }

    public virtual void NotFound(string message)
    {
        var problemDetails = new ProblemDetailsOtherRequest()
        {
            Title = message,
            Status = StatusCodes.Status404NotFound,
            Type = "Not Found"
        };

        ViewModel = new NotFoundObjectResult(problemDetails);
    }

    public virtual void Unauthorized(string message)
    {
        var problemDetails = new ProblemDetailsOtherRequest()
        {
            Title = message,
            Status = StatusCodes.Status401Unauthorized,
            Type = "Unauthorized"
        };

        ViewModel = new UnauthorizedObjectResult(problemDetails);
    }
}

