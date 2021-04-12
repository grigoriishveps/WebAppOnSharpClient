using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IDiseaseService
    {
        Task<IEnumerable<Disease>> GetDisease();
        Task<Disease> GetDisease(int id);
        Task<Disease> PutDisease(Disease disease);
        Task<Disease> PatchDisease(Disease disease);
    }
}