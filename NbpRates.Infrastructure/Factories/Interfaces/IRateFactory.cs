using NbpRatesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateDb = NbpRates.Database.Models.Rate;

namespace NbpRates.Infrastructure.Factories.Interfaces
{
    public interface IRateFactory
    {
        RateDb Create(Rate rate, DateTimeOffset effectiveDate);
    }
}
