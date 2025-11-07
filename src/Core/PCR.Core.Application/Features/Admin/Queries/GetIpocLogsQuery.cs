using MediatR;
using PCR.Core.Application.Common.Models;

namespace PCR.Core.Application.Features.Admin.Queries;

public record GetIpocLogsQuery : IRequest<Result<List<IpocLogDto>>>;

public record IpocLogDto(
    int Id,
    DateTime Date,
    string ContractCode,
    string ClientName,
    decimal Mwh,
    string Status,
    DateTime? ReplicatedAt
);

public class GetIpocLogsQueryHandler : IRequestHandler<GetIpocLogsQuery, Result<List<IpocLogDto>>>
{
    public async Task<Result<List<IpocLogDto>>> Handle(GetIpocLogsQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);

        var logs = new List<IpocLogDto>
        {
            new(1, new DateTime(2024, 10, 25), "CON001", "Cliente 1", 1250.5m, "Replicado", new DateTime(2024, 10, 26, 10, 30, 0)),
            new(2, new DateTime(2024, 10, 24), "CON002", "Cliente 2", 2100.75m, "Replicado", new DateTime(2024, 10, 25, 9, 15, 0)),
            new(3, new DateTime(2024, 10, 23), "CON001", "Cliente 1", 1180.0m, "Pendiente", null),
            new(4, new DateTime(2024, 10, 22), "CON003", "Cliente 3", 850.25m, "Replicado", new DateTime(2024, 10, 23, 14, 45, 0)),
            new(5, new DateTime(2024, 10, 21), "CON002", "Cliente 2", 1950.0m, "Error", null)
        };

        return Result<List<IpocLogDto>>.Success(logs);
    }
}
