using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWarsModel
{
    public record PeopleList
    {
        public PeopleList(IEnumerable<Person> people)
        {
            People = people;
        }
        
        public string? Next { get; init; }
        public string? Previous { get; init; }

        [JsonPropertyName("results")]
        public IEnumerable<Person> People { get; init; }
    }
}