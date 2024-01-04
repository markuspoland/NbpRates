using NbpRatesApp.Domain.Models;

namespace NbpRatesApp.Clients.Interfaces
{
    public interface INbpClient
    {
        Task<NbpTable> GetAsync();
    }
}
