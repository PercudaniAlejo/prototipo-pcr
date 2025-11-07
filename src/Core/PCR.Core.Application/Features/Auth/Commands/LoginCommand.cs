using MediatR;
using PCR.Core.Application.Common.Models;

namespace PCR.Core.Application.Features.Auth.Commands;

public record LoginCommand(string Username, string Password) : IRequest<Result<LoginResponse>>;

public record LoginResponse(string Token, string DisplayName, string Email);

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implementar lógica real con repositorio y hash de contraseñas

        // Mock de usuarios válidos
        var validUsers = new Dictionary<string, (string Password, string DisplayName, string Email)>
        {
            { "pablo", ("12345", "Pablo Santoro", "psantoro@pcr.energy") },
            { "favio", ("12345", "Favio Felice", "ffelice@pcr.energy") }
        };

        if (validUsers.TryGetValue(request.Username.ToLower(), out var user))
        {
            if (user.Password == request.Password) // En producción: usar hash
            {
                var response = new LoginResponse(
                    Token: Guid.NewGuid().ToString(), // En producción: generar JWT
                    DisplayName: user.DisplayName,
                    Email: user.Email
                );

                return Result<LoginResponse>.Success(response);
            }
        }

        return Result<LoginResponse>.Failure(new[] { "Usuario o contraseña incorrectos" });
    }
}