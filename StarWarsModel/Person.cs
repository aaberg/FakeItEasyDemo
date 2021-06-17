using System;
using System.Text.Json.Serialization;

namespace StarWarsModel
{
    public record Person
    {
        public Person(string name, string[] species)
        {
            Name = name;
            Species = species;
        }

        public string Name { get; init; }
        public string? Height { get; init; }
        public string? Mass { get; init; }
        [JsonPropertyName("hair_color")]
        public string? HairColor { get; init; }
        public string? Gender { get; init; }
        public string? HomeWorld { get; init; }
        
        public string[] Species { get; init; }
    }
}