using NbpRatesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbpRates.Infrastructure.Repositories.Interfaces
{
    public interface IRatesRepository
    {
        Task<string> AddAsync(IEnumerable<Rate> rates, DateTimeOffset effectiveDate);
    }
}
