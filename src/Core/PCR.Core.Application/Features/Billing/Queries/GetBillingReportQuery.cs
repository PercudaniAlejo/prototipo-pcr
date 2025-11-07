using MediatR;
using PCR.Core.Application.Common.Models;

namespace PCR.Core.Application.Features.Billing.Queries;

public record GetBillingReportQuery(string ContractId, string Period) : IRequest<Result<BillingReportDto>>;

public record BillingReportDto(
    string ContractCode,
    string ClientName,
    string Period,
    List<BillingItemDto> Items,
    decimal TotalMwh,
    decimal TotalAmount
);

public record BillingItemDto(
    string Description,
    decimal Mwh,
    decimal UnitPrice,
    decimal Amount
);

public class GetBillingReportQueryHandler : IRequestHandler<GetBillingReportQuery, Result<BillingReportDto>>
{
    public async Task<Result<BillingReportDto>> Handle(GetBillingReportQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);

        var items = new List<BillingItemDto>
        {
            new("Energía Base", 5000m, 150.50m, 752500m),
            new("Energía Pico", 2500m, 180.75m, 451875m),
            new("Energía Valle", 1800m, 120.00m, 216000m),
            new("Ajustes CAMMESA", 0m, 0m, -15000m)
        };

        var report = new BillingReportDto(
            request.ContractId,
            "Cliente Demo S.A.",
            request.Period,
            items,
            9300m,
            1405375m
        );

        return Result<BillingReportDto>.Success(report);
    }
}
