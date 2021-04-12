using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IStreetService
    {
        Task<IEnumerable<Street>> GetStreet();
        Task<Street> GetStreet(int id);
        Task<Street> PutStreet(Street street);
        Task<Street> PatchStreet(Street street);
    }
}