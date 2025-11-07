using MediatR;
using PCR.Core.Application.Common.Models;

namespace PCR.Core.Application.Features.Contracts.Queries;

public record GetAllContractsQuery : IRequest<Result<List<ContractDto>>>;

public record ContractDto(
    string Id,
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
    public async Task<Result<List<ContractDto>>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
    {
        // Mock data
        var contracts = new List<ContractDto>
        {
            new("CON001", "CON001", "Cliente 1", "Contrato MWH Norte", "Activo",
                new DateTime(2023, 3, 1), new DateTime(2025, 2, 28), 5000, 60000, "USD"),
            new("CON002", "CON002", "Cliente 2", "Contrato Renovable", "Draft",
                new DateTime(2025, 1, 1), new DateTime(2026, 12, 31), 1500, 18000, "USD"),
            new("CON003", "CON003", "Cliente 3", "Contrato 003", "Vencido",
                new DateTime(2023, 5, 1), new DateTime(2025, 4, 30), 3250, 39000, "ARS"),
            new("CON004", "CON004", "Cliente 4", "Contrato 004", "Vencido",
                new DateTime(2023, 8, 1), new DateTime(2025, 6, 30), 3250, 39000, "ARS"),
        };

        return await Task.FromResult(Result<List<ContractDto>>.Success(contracts));
    }
}