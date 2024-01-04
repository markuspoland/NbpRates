using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbpRates.Database.Models
{
    public class Rate
    {
        public Guid Id { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }
        public DateTimeOffset EffectiveDate { get; set; }
    }
}
