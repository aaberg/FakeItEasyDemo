using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StarWarsModel;
using StarWasProxy;

namespace StarWarsServices
{
    public class PeopleService : IPeopleService
    {
        private readonly ISwapiProxy _swapiProxy;
        private readonly ILogger<PeopleService> _logger;

        public const string DroidSpeciesUrl = "http://swapi.dev/api/species/2/";
        public const string HumanSpeciesUrl = "http://swapi.dev/api/species/1/";
        

        public PeopleService(ISwapiProxy swapiProxy, ILogger<PeopleService> logger)
        {
            _swapiProxy = swapiProxy;
            _logger = logger;
        }

        public async Task<IEnumerable<Person>> GetDroids()
        {
            return (await GetAllPeople()).Where(person => person.Species.Contains(DroidSpeciesUrl));
        }

        public async Task<IEnumerable<Person>> GetHumans()
        {
            return (await GetAllPeople()).Where(person => person.Species.Contains(HumanSpeciesUrl));
        }

        private async Task<IEnumerable<Person>> GetAllPeople()
        {
            IEnumerable<Person> allPeople = Array.Empty<Person>();
            var page = 1;
            var hasMoreResults = true;
            while (hasMoreResults)
            {
                PeopleList peopleList;
                try
                {
                    peopleList = await _swapiProxy.GetPeople(page++);;
                }
                catch (Exception e)
                {
                    _logger.LogError(e,"Error calling swapi api");
                    throw;
                }
                allPeople = allPeople.Concat(peopleList.People);
                hasMoreResults = !string.IsNullOrEmpty(peopleList.Next);
            }

            return allPeople;
        }
    }
}