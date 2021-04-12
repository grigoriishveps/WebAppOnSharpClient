using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatient();
        Task<Patient> GetPatient(int id);
        Task<Patient> PutPatient(Patient patient);
        Task<Patient> PatchPatient(Patient patient);
    }
}