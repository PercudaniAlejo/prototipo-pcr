using MediatR;
using PCR.Core.Application.Common.Models;

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
    public async Task<Result<List<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        // Mock data
        var clients = new List<ClientDto>
        {
            new(1, "Cliente 1", "Cliente 03", false, true),
            new(2, "Cliente 2", "Cliente 01", false, true),
            new(3, "Cliente 3", "Cliente 02", true, false),
            new(4, "Cliente 4", "Cliente 04", true, true),
        };

        return await Task.FromResult(Result<List<ClientDto>>.Success(clients));
    }
}
