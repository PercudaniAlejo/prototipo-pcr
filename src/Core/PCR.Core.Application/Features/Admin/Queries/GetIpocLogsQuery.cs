using MediatR;
using PCR.Core.Application.Common.Models;
using PCR.Core.Application.Interfaces.Services;

namespace PCR.Core.Application.Features.Admin.Queries;

public record GetIpocLogsQuery : IRequest<Result<List<IpocLogDto>>>;

public record IpocLogDto(
    DateTime Timestamp,
    string Periodo,
    string AgeId,
    string NemoCliente,
    string NemoGenerador,
    string EtotalPlus,
    string EtotalRen,
    bool Status
);

public class GetIpocLogsQueryHandler : IRequestHandler<GetIpocLogsQuery, Result<List<IpocLogDto>>>
{
    private readonly IMockDataService _mockDataService;

    public GetIpocLogsQueryHandler(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    public async Task<Result<List<IpocLogDto>>> Handle(GetIpocLogsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var logs = await _mockDataService.GetMockDataAsync<IpocLogDto>("ipoc-logs.json");

            if (logs.Count == 0)
            {
                return Result<List<IpocLogDto>>.Success(new List<IpocLogDto>());
            }

            return Result<List<IpocLogDto>>.Success(logs);
        }
        catch (Exception ex)
        {
            return Result<List<IpocLogDto>>.Failure($"Error al cargar logs IPOC: {ex.Message}");
        }
    }
}