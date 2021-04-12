using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class DoctorService: IDoctorService
    {
        private HttpClient HttpClient { get; }
        
        public DoctorService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctor()
        {
            using var response = await this.HttpClient.GetAsync("api/doctor");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Doctor>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/doctor/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Doctor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Doctor> PutDoctor(Doctor doctor)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(doctor), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/doctor",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Doctor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Doctor> PatchDoctor(Doctor doctor)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(doctor), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/doctor",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Doctor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}