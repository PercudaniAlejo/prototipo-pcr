using MediatR;
using PCR.Core.Application.Common.Models;
using PCR.Core.Application.Features.Clients.Queries;
using PCR.Core.Application.Interfaces.Services;

namespace PCR.Core.Application.Features.Contracts.Queries;

public record GetAllContractsQuery : IRequest<Result<List<ContractDto>>>;

public record ContractDto(
    int Id,
    string Code,
    string ClientName,
    string Name,
    string Status,
    DateTime StartDate,
    DateTime EndDate,
    decimal MonthlyEnergy,
    decimal AnnualEnergy,
    string Currency
);

public class GetAllContractsQueryHandler : IRequestHandler<GetAllContractsQuery, Result<List<ContractDto>>>
{
    private readonly IMockDataService _mockDataService;

    public GetAllContractsQueryHandler(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    public async Task<Result<List<ContractDto>>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var contracts = await _mockDataService.GetMockDataAsync<ContractDto>("contracts.json");

            if (contracts.Count == 0)
            {
                return Result<List<ContractDto>>.Success(new List<ContractDto>());
            }

            return Result<List<ContractDto>>.Success(contracts);
        }
        catch (Exception ex)
        {
            return Result<List<ContractDto>>.Failure($"Error al cargar contratos: {ex.Message}");
        }
    }
}