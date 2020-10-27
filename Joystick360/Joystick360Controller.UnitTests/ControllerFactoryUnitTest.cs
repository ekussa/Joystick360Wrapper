using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class ControllerFactoryUnitTest
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ShouldCreate(int index)
        {
            //Arrange
            var controllerFactory = new ControllerFactory();
            
            //Act
            var result = controllerFactory.Create(index);

            //Assert
            result.Index.Should().Be(index);
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ShouldSetup(int index)
        {
            //Arrange
            var mock = new Mock<IControllerTimedPoll>(MockBehavior.Strict);
            mock.Setup(_ => _.Remove(index)).Returns(true);
            var controllerFactory = new ControllerFactory();
            controllerFactory.Setup(new ControllerFactoryArguments{ControllerTimedPoll = mock.Object,});
            using (var result = controllerFactory.Create(index))
            {
                //Act & Assert
                result.Dispose();
                mock.VerifyAll();
            }
        }
    }
}
