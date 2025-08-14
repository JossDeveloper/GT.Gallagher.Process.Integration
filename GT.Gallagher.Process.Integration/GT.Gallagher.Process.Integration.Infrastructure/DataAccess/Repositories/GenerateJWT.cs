using GT.Gallagher.Process.Integration.Application.Repository.Login;
using GT.Gallagher.Process.Integration.Domain.Token;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories;

public class GenerateJWT : IGenerateJWT
{
    public TokenValidateResponse GenerateJsonWebToken(string user)
    {
        var expirationTime = int.Parse(Environment.GetEnvironmentVariable("TOKEN_EXPIRATION_TIME_IN_MINUTES") ?? "30");
        var tokenValidateResponse = new TokenValidateResponse(user);
        var tokenDescriptor = GetTokenDescriptor(tokenValidateResponse, expirationTime);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenResponse = new TokenValidateResponse(user)
        {
            Expires = tokenDescriptor.Expires,
            Token = tokenHandler.WriteToken(token),
            ExpirationTimeInMinutes = expirationTime
        };
        return tokenResponse;
    }

    private SecurityTokenDescriptor GetTokenDescriptor(TokenValidateResponse tokenValidateResponse, int expirationTime)
    {
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Company", tokenValidateResponse.Company),
                new Claim("User", tokenValidateResponse.User),
                new Claim("RoleName", tokenValidateResponse.RoleName),
            }),
            Expires = DateTime.UtcNow.AddMinutes(expirationTime),
            SigningCredentials = credentials,
        };
        return tokenDescriptor;
    }
}

