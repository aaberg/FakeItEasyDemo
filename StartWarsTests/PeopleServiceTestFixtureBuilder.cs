using System;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using StarWarsModel;
using StarWarsServices;
using StarWasProxy;

namespace StartWarsTests
{
    public class PeopleServiceTestFixtureBuilder
    {
        private readonly ISwapiProxy _swapiProxy = A.Fake<ISwapiProxy>();
        public readonly ILogger<PeopleService> Logger = A.Fake<ILogger<PeopleService>>();

        public PeopleServiceTestFixtureBuilder WithSimulatedDataSource()
        {
            A.CallTo(() => _swapiProxy.GetPeople(1))
                .Returns(Task.FromResult(new PeopleList(TestData.PersonsPage1) {Next = "2"}));
            A.CallTo(() => _swapiProxy.GetPeople(2))
                .Returns(Task.FromResult(new PeopleList(TestData.PersonsPage2) {Next = null}));

            return this;
        }

        public PeopleServiceTestFixtureBuilder WithExceptionFromProxy()
        {
            A.CallTo(() => _swapiProxy.GetPeople(A<int>._)).ThrowsAsync(new Exception("ouch, error!"));

            return this;
        }
        
        public IPeopleService Build()
        {
            return new PeopleService(_swapiProxy, Logger);
        }
    }
}