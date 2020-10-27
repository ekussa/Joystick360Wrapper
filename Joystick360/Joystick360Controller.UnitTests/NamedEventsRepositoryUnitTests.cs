using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class NamedEventsRepositoryUnitTests
    {
        private const string NameEvents1 = "events1";
        private const string NameEvents2 = "events2";

        private ConcreteControllerEvents _events1;
        private ConcreteControllerEvents _events2;
        private NamedEventsRepository _namedEventsRepository;

        [SetUp]
        public void Setup()
        {
            _events1 = new ConcreteControllerEvents();
            _events2 = new ConcreteControllerEvents();
            _namedEventsRepository = new NamedEventsRepository();
        }
        
        [Test]
        public void ShouldCreateAndGet_SingleRegistry()
        {
            //Act
            var createResult = _namedEventsRepository.Create(NameEvents1, _events1);
            var getResult = _namedEventsRepository.Get(NameEvents1);

            //Assert
            createResult.Should().BeTrue();
            getResult.Should().Be(_events1);
        }
        
        [Test]
        public void ShouldCreateAndGet_TwoRegistries()
        {
            //Arrange
            _namedEventsRepository.Create(NameEvents1, _events1);
            _namedEventsRepository.Create(NameEvents2, _events2);

            //Act
            var result1 = _namedEventsRepository.Get(NameEvents1);
            var result2 = _namedEventsRepository.Get(NameEvents2);

            //Assert
            result1.Should().Be(_events1);
            result2.Should().Be(_events2);
        }
        
        [Test]
        public void ShouldGetAll_TwoRegistries()
        {
            //Arrange
            _namedEventsRepository.Create(NameEvents1, _events1);
            _namedEventsRepository.Create(NameEvents2, _events2);

            //Act
            var result = _namedEventsRepository.GetAll();

            //Assert
            result.Count().Should().Be(2);
        }
        
        [Test]
        public void ShouldGetMultiple_TwoRegistries()
        {
            //Arrange
            _namedEventsRepository.Create(NameEvents1, _events1);
            _namedEventsRepository.Create(NameEvents2, _events2);

            //Act
            var result = _namedEventsRepository.Get(new List<string>{NameEvents1, NameEvents2});

            //Assert
            result.Count().Should().Be(2);
        }
        
        [Test]
        public void ShouldConstructFromDictionary_TwoRegistries()
        {
            //Arrange
            var dic = new Dictionary<string, IControllerEvents> {{NameEvents1, _events1}, {NameEvents2, _events2}};
            var namedEventsRepository = new NamedEventsRepository(dic);

            //Act
            var result = namedEventsRepository.GetAll();

            //Assert
            result.Count().Should().Be(2);
        }
    }
}