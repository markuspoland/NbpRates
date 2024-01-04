using NbpRatesApp.Clients.Interfaces;
using NbpRatesApp.Domain.Models;

namespace NbpRatesApp.Clients
{
    public class NbpClient : INbpClient
    {
        private const string Uri = "http://api.nbp.pl/api/exchangerates/tables/a/";

        public async Task<NbpTable> GetAsync()
        {
            var httpClient = new HttpClient();

            var nbpTables = await httpClient.GetFromJsonAsync<NbpTable[]>(Uri);

            return nbpTables[0];
        }
    }
}
