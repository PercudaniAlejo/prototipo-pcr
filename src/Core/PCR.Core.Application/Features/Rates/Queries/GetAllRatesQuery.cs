using MediatR;
using PCR.Core.Application.Common.Models;

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
    public async Task<Result<List<RateDto>>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);

        var rates = new List<RateDto>
        {
            new(1, "DÓLAR BANCO NACION", 950.00m, new DateTime(2024, 10, 30)),
            new(2, "DÓLAR BANCO NACION", 960.00m, new DateTime(2024, 11, 30)),
            new(3, "DÓLAR BANCO NACION", 970.00m, null),
            new(4, "EURO", 1050.00m, new DateTime(2024, 10, 30)),
            new(5, "A3500", 950.00m, new DateTime(2024, 10, 30)),
            new(6, "A3500", 960.00m, new DateTime(2024, 11, 30)),
            new(7, "A3500", 970.00m, null),
            new(9, "TASA SOFT", 3.50m, null)
        };

        return Result<List<RateDto>>.Success(rates);
    }
}
