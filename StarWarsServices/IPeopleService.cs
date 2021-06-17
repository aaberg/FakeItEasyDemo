using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsModel;
using StarWasProxy;

namespace StarWarsServices
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetDroids();

        Task<IEnumerable<Person>> GetHumans();
    }
}