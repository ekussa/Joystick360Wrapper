using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class NamedAndCreatableEventsRepositoryUnitTests
    {
        private const string NameEvents1 = "Events1";
        
        [Test]
        public void ShouldCreateEvents()
        {
            //Arrange
            var creatableEvents = new UnitTestsCreatableEvents();
            var namedAndCreatableEventsRepository = new NamedAndCreatableEventsRepository();

            //Act
            var result = namedAndCreatableEventsRepository.Create(NameEvents1, creatableEvents);

            //Assert
            result.Should().BeTrue();
            namedAndCreatableEventsRepository.GetAll().Any().Should().BeTrue();

        }
        
        [Test]
        public void ShouldNotCreateEvents_WhenAlreadyExistingKeyGiven()
        {
            //Arrange
            var creatableEvents = new UnitTestsCreatableEvents();
            var namedAndCreatableEventsRepository = new NamedAndCreatableEventsRepository(
                new Dictionary<string, IControllerEvents>{{NameEvents1, new ConcreteControllerEvents()}});

            //Act
            var result = namedAndCreatableEventsRepository.Create(NameEvents1, creatableEvents);

            //Assert
            result.Should().BeFalse();
            namedAndCreatableEventsRepository.GetAll().Any().Should().BeTrue();

        }
    }
}