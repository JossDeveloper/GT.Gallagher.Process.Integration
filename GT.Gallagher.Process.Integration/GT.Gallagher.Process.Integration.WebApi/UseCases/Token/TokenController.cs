using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Login;
using Microsoft.AspNetCore.Mvc;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Token;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ILoginUseCase loginUseCase;
    private readonly TokenPresenter tokenPresenter;

    public TokenController(ILoginUseCase loginUseCase, TokenPresenter tokenPresenter)
    {
        this.loginUseCase = loginUseCase;
        this.tokenPresenter = tokenPresenter;
    }

    [HttpPost()]
    [ProducesResponseType(typeof(TokenResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("Login")]
    public IActionResult GetToken([FromBody] TokenRequest request)
    {
        var loginRequest = new LoginRequest(request.Username, request.Password);
        loginUseCase.Execute(loginRequest);

        return tokenPresenter.ViewModel;
    }
}

