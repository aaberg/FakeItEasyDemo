using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsModel;

namespace StarWasProxy
{
    public interface ISwapiProxy
    {
        Task<PeopleList> GetPeople(int page = 1);
        Task<Person> GetPerson(int id);
    }
}