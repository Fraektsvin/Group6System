using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Models;

namespace BlazorClient.Data
{
    public class InMemoryUser: ICustomerService
    {
        private readonly HttpClient _client = new HttpClient();
        private string path = "http://localhost:8080";

        public async Task<Customer> ValidateUserAsync(string username, string password)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/users?username={username}&password={password}");
            if (response.IsSuccessStatusCode)
            {
                string AsJson = await response.Content.ReadAsStringAsync();
                Customer login = JsonSerializer.Deserialize<Customer>(AsJson, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return login;
            }

            throw new Exception($"{await response.Content.ReadAsStringAsync()}");
        }

        public async Task AddUserAsync(Customer user)
        {
            string AsJson = JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            
            StringContent content = new StringContent(
                AsJson,Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _client.PostAsync($"{path}/createNewUser", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}