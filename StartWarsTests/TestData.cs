using FakeItEasy;
using StarWarsModel;
using StarWarsServices;

namespace StartWarsTests
{
    public static class TestData
    {
        public static readonly Person[] PersonsPage1 = new[]
        {
            new Person("Luke", new[] {PeopleService.HumanSpeciesUrl}),
            new Person("Leia", new[] {PeopleService.HumanSpeciesUrl}),
        };
        
        public static readonly Person[] PersonsPage2 = new[]
        {
            new Person("R2D2", new[] {PeopleService.DroidSpeciesUrl}),
            new Person("Darth Vader", new[] {PeopleService.HumanSpeciesUrl}),
        };
    }
}