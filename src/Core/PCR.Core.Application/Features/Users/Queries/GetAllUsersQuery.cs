using MediatR;
using PCR.Core.Application.Common.Models;

namespace PCR.Core.Application.Features.Users.Queries;

public record GetAllUsersQuery : IRequest<Result<List<UserDto>>>;

public record UserDto(
    int Id,
    string Username,
    string Name,
    string Surname,
    string Email,
    string Phone,
    bool Enabled
);

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserDto>>>
{
    public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        // Mock data
        var users = new List<UserDto>
        {
            new(1, "pablo", "Pablo", "Santoro", "psantoro@pcr.energy", "-", true),
            new(2, "favio", "Favio", "Felice", "ffelice@pcr.energy", "-", true),
            new(3, "ignacio", "Ignacio", "Lopez", "jilopez@pcr.energy", "-", false),
        };

        return await Task.FromResult(Result<List<UserDto>>.Success(users));
    }
}
