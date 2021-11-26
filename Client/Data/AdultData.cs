using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public class AdultData : IAdultData
    {
        public IList<Adult> Adults { get; set; }
        private readonly HttpClient client;

        public AdultData()
        {
            Adults = new List<Adult>();
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5002/Adults");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return adults;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = ++max;
            Adults.Add(adult);

            StringContent content =
                new StringContent(JsonSerializer.Serialize(Adults), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:5002/Adults", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAdultAsync(Adult adult)
        {
            // Adult update = Adults.First(t => t.Id == adult.Id);
            // update.FirstName = adult.FirstName;
            // update.LastName = adult.LastName;
            // update.HairColor = adult.HairColor;
            // update.EyeColor = adult.EyeColor;
            // update.Age = adult.Age;
            // update.Height = adult.Height;
            // update.Weight = adult.Weight;
            // update.Sex = adult.Sex;
            // update.JobTitle = adult.JobTitle;
            //
            // StringContent content =
            //     new StringContent(JsonSerializer.Serialize(Adults), Encoding.UTF8, "application/json");
            // HttpResponseMessage response = await client.PostAsync("https://localhost:5002/Adults", content);
            // response.EnsureSuccessStatusCode();
            
            var adultAsJson = JsonSerializer.Serialize(adult);
            var content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );
            var responseMessage = await client.PatchAsync("https://localhost:5002/Adults",content);
            if(!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task DeleteAdultsAsync(Adult adult)
        {
            Adults.Remove(adult);
            
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:5002/Adults" + $"/{adult.Id}");
            response.EnsureSuccessStatusCode();
        }

        public Adult GetId(int id)
        {
            return Adults.FirstOrDefault(t => t.Id == id);
        }
    }
}