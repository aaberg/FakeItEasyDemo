using System;
using System.Linq;
using System.Threading.Tasks;
using StarWarsServices;

namespace StarWarsCli
{
    public class App
    {
        private readonly IPeopleService _peopleService;
        
        public App(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Droids:");
            var droids = await _peopleService.GetDroids();
            Console.WriteLine(string.Join("\n", droids.Select(d => d.Name)));
            
            Console.WriteLine("\nHumans:");
            Console.WriteLine(string.Join("\n", (await _peopleService.GetHumans()).Select(person => person.Name)));
        } 
    }
}