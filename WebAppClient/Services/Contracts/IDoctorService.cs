using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctor();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> PutDoctor(Doctor doctor);
        Task<Doctor> PatchDoctor(Doctor doctor);
    }
}