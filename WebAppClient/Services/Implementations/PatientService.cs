using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class PatientService:IPatientService
    {
        private HttpClient HttpClient { get; }
        
        public PatientService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Patient>> GetPatient()
        {
            using var response = await this.HttpClient.GetAsync("api/patient");
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Patient>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Patient> GetPatient(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/patient/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Patient>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Patient> PutPatient(Patient patient)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/patient",sendContent);
            System.Console.WriteLine(" fdfsdf"  + JsonSerializer.Serialize(patient));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Patient>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Patient> PatchPatient(Patient patient)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/patient",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Patient>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}