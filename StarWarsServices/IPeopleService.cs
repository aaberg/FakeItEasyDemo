using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsModel;

namespace StarWarsServices
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetDroids();

        Task<IEnumerable<Person>> GetHumans();
    }
}