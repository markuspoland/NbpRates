using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NbpRates.Infrastructure.Repositories.Interfaces;
using NbpRatesApp.Clients;
using NbpRatesApp.Clients.Interfaces;
using NbpRatesApp.Domain.Models;
using Newtonsoft.Json;
using System.Text;

namespace NbpRatesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRatesRepository _ratesRepository;
        private readonly INbpClient _nbpClient;

        public List<Rate> Rates { get; set; }
        public DateTimeOffset EffectiveDate { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IRatesRepository ratesRepository, INbpClient nbpClient)
        {
            _logger = logger;
            _ratesRepository = ratesRepository;
            _nbpClient = nbpClient;
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.TryGetValue("Rates", out var ratesBytes))
            {
                Rates = JsonConvert.DeserializeObject<List<Rate>>(Encoding.UTF8.GetString(ratesBytes));
            }
            else
            {
                var nbpTable = await _nbpClient.GetAsync();
                Rates = nbpTable.Rates.ToList();
                EffectiveDate = nbpTable.EffectiveDate;

                HttpContext.Session.Set("EffectiveDate", Encoding.UTF8.GetBytes(EffectiveDate.ToString()));
                HttpContext.Session.Set("Rates", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Rates)));
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSaveToDatabaseAsync()
        {
            var ratesBytes = HttpContext.Session.Get("Rates");
            var dateBytes = HttpContext.Session.Get("EffectiveDate");

            var rates = JsonConvert.DeserializeObject<List<Rate>>(Encoding.UTF8.GetString(ratesBytes));
            var effectiveDate = DateTimeOffset.Parse(Encoding.UTF8.GetString(dateBytes));

            var result = await _ratesRepository.AddAsync(rates, effectiveDate);

            TempData["ResultMessage"] = result;

            HttpContext.Session.Remove("Rates");
            HttpContext.Session.Remove("EffectiveDate");

            return RedirectToPage();
        }
    }
}