using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class StreetService:IStreetService
    {
        private HttpClient HttpClient { get; }
        
        public StreetService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Street>> GetStreet()
        {
            using var response = await this.HttpClient.GetAsync("api/street");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Street>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Street> GetStreet(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/street/" + id);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Street>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Street> PutStreet(Street street)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(street), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/street",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Street>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Street> PatchStreet(Street street)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(street), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/street",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Street>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}