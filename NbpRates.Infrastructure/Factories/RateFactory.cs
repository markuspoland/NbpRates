using NbpRates.Infrastructure.Factories.Interfaces;
using NbpRatesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateDb = NbpRates.Database.Models.Rate;

namespace NbpRates.Infrastructure.Factories
{
    public class RateFactory : IRateFactory
    {
        public RateDb Create(Rate rate, DateTimeOffset effectiveDate)
        {
            return new RateDb
            {
                Id = Guid.NewGuid(),
                Currency = rate.Currency,
                Code = rate.Code,
                Mid = rate.Mid,
                EffectiveDate = effectiveDate,
            };
        }
    }
}
