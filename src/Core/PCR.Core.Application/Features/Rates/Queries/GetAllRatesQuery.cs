using MediatR;
using PCR.Core.Application.Common.Models;
using PCR.Core.Application.Features.Contracts.Queries;
using PCR.Core.Application.Interfaces.Services;

namespace PCR.Core.Application.Features.Rates.Queries;

public record GetAllRatesQuery : IRequest<Result<List<RateDto>>>;

public record RateDto(
    int Id,
    string Name,
    decimal Value,
    DateTime? ValidUntil
);

public class GetAllRatesQueryHandler : IRequestHandler<GetAllRatesQuery, Result<List<RateDto>>>
{
    private readonly IMockDataService _mockDataService;

    public GetAllRatesQueryHandler(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }
    public async Task<Result<List<RateDto>>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var rates = await _mockDataService.GetMockDataAsync<RateDto>("rates.json");

            if (rates.Count == 0)
            {
                return Result<List<RateDto>>.Success(new List<RateDto>());
            }

            return Result<List<RateDto>>.Success(rates);
        }
        catch (Exception ex)
        {
            return Result<List<RateDto>>.Failure($"Error: {ex.Message}");
        }
    }
}
