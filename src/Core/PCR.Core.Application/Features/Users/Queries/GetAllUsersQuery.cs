using MediatR;
using PCR.Core.Application.Common.Models;
using PCR.Core.Application.Interfaces.Services;

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
    private readonly IMockDataService _mockDataService;

    public GetAllUsersQueryHandler(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _mockDataService.GetMockDataAsync<UserDto>("users.json");

            if (users.Count == 0)
            {
                return Result<List<UserDto>>.Success(new List<UserDto>());
            }

            return Result<List<UserDto>>.Success(users);
        }
        catch (Exception ex)
        {
            return Result<List<UserDto>>.Failure($"Error al cargar usuarios: {ex.Message}");
        }
    }
}
