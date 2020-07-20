using MetroApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetroApp.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Station>> GetStationsAsync(string queryString);
        Task AddStationsAsync(IEnumerable<Station> stations);
    }
}