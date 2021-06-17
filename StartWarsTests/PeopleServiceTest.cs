using System;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using StarWarsServices;
using Xunit;

namespace StartWarsTests
{
    public class PeopleServiceTest
    {
        private readonly PeopleServiceTestFixtureBuilder _fixtureBuilder = new();

        [Fact]
        public async Task GetDroids_ReturnsOnlyDroids()
        {
            var peopleService = _fixtureBuilder.WithSimulatedDataSource().Build();

            var droids = (await peopleService.GetDroids()).ToArray();

            droids.Should().OnlyContain(person => person.Species[0] == PeopleService.DroidSpeciesUrl);
            droids.Should().HaveCount(1);
        }
        
        [Fact]
        public async Task GetHumans_ReturnsOnlyHumans()
        {
            var peopleService = _fixtureBuilder.WithSimulatedDataSource().Build();

            var droids = (await peopleService.GetHumans()).ToArray();

            droids.Should().OnlyContain(person => person.Species[0] == PeopleService.HumanSpeciesUrl);
            droids.Should().HaveCount(3);
        }

        [Fact]
        public async Task GetHumans_ProxyThrows_LogError()
        {
            var peopleService = _fixtureBuilder.WithExceptionFromProxy().Build();

            await Assert.ThrowsAsync<Exception>(() => _ = peopleService.GetHumans());

            A.CallTo(_fixtureBuilder.Logger)
                .Where(call => call.Method.Name == "Log" && call.Arguments[0].As<LogLevel>() == LogLevel.Error)
                .MustHaveHappenedOnceExactly();
        }
        
    }
}