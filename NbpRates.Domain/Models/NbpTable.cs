namespace NbpRatesApp.Domain.Models
{
    public class NbpTable
    {
        public string Table { get; set; }
        public string No { get; set; }
        public DateTimeOffset EffectiveDate { get; set; }
        public Rate[] Rates { get; set; }
    }
}
