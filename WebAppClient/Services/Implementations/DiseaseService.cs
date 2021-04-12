using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class DiseaseService:IDiseaseService
    {
        private HttpClient HttpClient { get; }
        
        public DiseaseService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Disease>> GetDisease()
        {
            using var response = await this.HttpClient.GetAsync("api/disease");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Disease>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Disease> GetDisease(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/disease/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Disease>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Disease> PutDisease(Disease disease)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(disease), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/disease",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Disease>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Disease> PatchDisease(Disease disease)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(disease), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/disease",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Disease>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}