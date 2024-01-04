using NbpRates.Database;
using NbpRates.Infrastructure.Factories.Interfaces;
using NbpRates.Infrastructure.Repositories.Interfaces;
using NbpRatesApp.Domain.Models;

namespace NbpRates.Infrastructure.Repositories
{
    public class RatesRepository : IRatesRepository
    {
        private readonly NbpRatesDbContext _context;
        private readonly IRateFactory _rateFactory;

        public RatesRepository(NbpRatesDbContext context, IRateFactory rateFactory)
        {
            _context = context;
            _rateFactory = rateFactory;
        }

        public async Task<string> AddAsync(IEnumerable<Rate> rates, DateTimeOffset effectiveDate)
        {
            await using (_context)
            {
                if (_context.Rates.Any(r => r.EffectiveDate == effectiveDate)) 
                    return "Rates not saved - current rates are already in the database.";

                _context.Rates.AddRange(rates.Select(r => _rateFactory.Create(r, effectiveDate)));

                var addedRates = await _context.SaveChangesAsync();

                return addedRates > 0 ? "Rates have been saved." : "Rates failed to save.";
            }
        }
    }
}