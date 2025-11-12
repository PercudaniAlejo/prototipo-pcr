using MediatR;
using PCR.Core.Application.Common.Models;
using PCR.Core.Application.Interfaces.Services;

namespace PCR.Core.Application.Features.Billing.Queries;

public record GetBillingItemsQuery(string? ContractCode = null, string? Period = null) : IRequest<Result<List<BillingItemDto>>>;

public record BillingItemDto(
    int Id,
    string ContractCode,
    string Period,
    string NemoCliente,
    string Description,
    string? NemoGenerador,
    string Quantity,
    string UnitPrice,
    string Amount,
    string Currency,
    string Concept
);

public class GetBillingReportQueryHandler : IRequestHandler<GetBillingItemsQuery, Result<List<BillingItemDto>>>
{
    private readonly IMockDataService _mockDataService;

    public GetBillingReportQueryHandler(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    public async Task<Result<List<BillingItemDto>>> Handle(GetBillingItemsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var items = await _mockDataService.GetMockDataAsync<BillingItemDto>("billing-items.json");

            if (!string.IsNullOrWhiteSpace(request.ContractCode))
            {
                items = items.Where(i => i.ContractCode == request.ContractCode).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Period))
            {
                items = items.Where(i => i.Period == request.Period).ToList();
            }

            return Result<List<BillingItemDto>>.Success(items);
        }
        catch (Exception ex)
        {
            return Result<List<BillingItemDto>>.Failure($"Error al cargar items de facturación: {ex.Message}");
        }
    }
}
