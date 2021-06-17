using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using StarWarsModel;

namespace StarWasProxy
{
    public class SwapiProxy : ISwapiProxy
    {
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
            {WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        public SwapiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<PeopleList> GetPeople(int page = 1)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://swapi.dev/api/people/?page={page}");
            var response = await _httpClient.SendAsync(httpRequestMessage);

            var json =await response.Content.ReadAsStringAsync();
            var people = JsonSerializer.Deserialize<PeopleList>(json, _jsonSerializerOptions);

            return people == null ? new PeopleList(Array.Empty<Person>()) : people;
        }
    }
}