using MediatR;
using PCR.Core.Application.Common.Models;
using PCR.Core.Application.Features.Users.Queries;
using PCR.Core.Application.Interfaces.Services;
using PCR.Core.Domain.Entities;

namespace PCR.Core.Application.Features.Clients.Queries;

public record GetAllClientsQuery : IRequest<Result<List<ClientDto>>>;

public record ClientDto(
    int Id,
    string Name,
    string Description,
    bool Enabled,
    bool Active
);

public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, Result<List<ClientDto>>>
{
    private readonly IMockDataService _mockDataService;

    public GetAllClientsQueryHandler(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    public async Task<Result<List<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var clients = await _mockDataService.GetMockDataAsync<ClientDto>("clients.json");

            if (clients.Count == 0)
            {
                return Result<List<ClientDto>>.Success(new List<ClientDto>());
            }

            return Result<List<ClientDto>>.Success(clients);
        }
        catch (Exception ex)
        {
            return Result<List<ClientDto>>.Failure($"Error al cargar clientes: {ex.Message}");
        }
    }
}
