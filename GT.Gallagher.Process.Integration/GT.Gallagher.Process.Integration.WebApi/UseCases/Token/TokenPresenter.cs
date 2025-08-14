using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.Application.UseCase.Login;
using GT.Gallagher.Process.Integration.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Token;

public class TokenPresenter : Presenter, IOutputPort<LoginResponse>
{
    public void Standard(LoginResponse output)
        => ViewModel = new OkObjectResult(new TokenResponse(output.Token, output.ExpirationTimeInSeconds));
}
