using MediatR;
using PCR.Core.Application.Common.Models;

namespace PCR.Core.Application.Features.Dashboard.Queries;

public record GetDashboardKpisQuery : IRequest<Result<DashboardKpisDto>>;

public record DashboardKpisDto(
    decimal MwhTotalLastMonth,
    decimal BilledAmountLastMonth,
    int ActiveClients,
    int DaysToCammesaClose
);

public class GetDashboardKpisQueryHandler : IRequestHandler<GetDashboardKpisQuery, Result<DashboardKpisDto>>
{
    public async Task<Result<DashboardKpisDto>> Handle(GetDashboardKpisQuery request, CancellationToken cancellationToken)
    {
        // Mock data - En producción consultar repositorio
        var kpis = new DashboardKpisDto(
            MwhTotalLastMonth: 9300,
            BilledAmountLastMonth: 450000000,
            ActiveClients: 4,
            DaysToCammesaClose: 5
        );

        return await Task.FromResult(Result<DashboardKpisDto>.Success(kpis));
    }
}