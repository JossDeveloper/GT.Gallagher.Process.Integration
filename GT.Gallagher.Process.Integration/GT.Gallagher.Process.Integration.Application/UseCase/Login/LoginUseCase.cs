using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.Application.Repository.Login;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly ILoginRepository loginRepository;
    private readonly IGenerateJWT generateJWT;
    private readonly IOutputPort<LoginResponse> outputPort;

    public LoginUseCase(ILoginRepository loginRepository,
        IGenerateJWT generateJWT,
        IOutputPort<LoginResponse> outputPort)
    {
        this.loginRepository = loginRepository;
        this.generateJWT = generateJWT;
        this.outputPort = outputPort;
    }

    public void Execute(LoginRequest request)
    {
        try
        {
            var isUserValid = loginRepository.ValidateLogin(request.User, request.Pass);

            if (!isUserValid)
            {
                outputPort.Unauthorized("Usuario y/o Clave no validos");
                return;
            }

            var token = generateJWT.GenerateJsonWebToken(request.User);

            outputPort.Standard(new LoginResponse(token.Token, token.ExpirationTimeInSeconds));
        }
        catch (Exception ex)
        {
            var message = $"Occurring an error to generate a Token. Error: {ex.InnerException?.Message ?? ex.Message}, stacktrace: {ex.StackTrace}";

            outputPort.ErrorServer(message);
        }
    }
}

