using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Application.Boundaries;

public interface IOutputPort<T>
{
    void ErrorServer(string message);
    void Error(List<ValidationFailure> details);
    void Error(List<ProblemDetail> details);
    void NotFound(string v);
    void Unauthorized(string message);
    void Standard(T output);
}

