using System.Linq;
using System.Threading;
using FluentAssertions;
using Joystick360Controller.Driver;
using Joystick360Controller.Structs;
using Moq;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class ControllerTimedPollUnitTests
    {
        private const int PollInterval = 10;
        private const int IndexKey = 1;

        private ControllerTimedPoll _controllerTimedPoll;

        private Mock<IInput> _inputMock;
        private MockRepository _repositoryMock;
        private Mock<IControllerFactory> _controllerFactoryMock;

        [SetUp]
        public void Setup()
        {
            _controllerTimedPoll = new ControllerTimedPoll();
            
            _repositoryMock = new MockRepository(MockBehavior.Strict);
            _inputMock = _repositoryMock.Create<IInput>();
            _controllerFactoryMock = _repositoryMock.Create<IControllerFactory>();
        }
        
        [Test]
        public void ShouldStartAndReturnTrue_WhenNotYetStarted()
        {
            var controllerTimedPoll = new ControllerTimedPoll();
            
            //Act
            var result = controllerTimedPoll.Start(_controllerFactoryMock.Object, _inputMock.Object, PollInterval);
            
            //Assert
            result.Should().BeTrue();
        }

        [Test]
        public void ShouldStartAndReturnFalse_WhenStartedYet()
        {
            //Arrange
            var firstResult = _controllerTimedPoll.Start(_controllerFactoryMock.Object, _inputMock.Object, PollInterval);

            //Act
            var secondResult = _controllerTimedPoll.Start(_controllerFactoryMock.Object, _inputMock.Object, PollInterval);
            
            //Assert
            firstResult.Should().BeTrue();
            secondResult.Should().BeFalse();
        }

        [Test]
        public void ShouldCreateNewInstance_WhenNotOfTheSameIdWereBefore()
        {
            //Arrange
            var controllerTimedPoll = new ControllerTimedPoll();
            controllerTimedPoll.Start(new ControllerFactory(), new Input(), PollInterval);

            //Act
            var result = controllerTimedPoll.CreateOrGet(IndexKey);
            
            //Assert
            result.Index.Should().Be(IndexKey);
            controllerTimedPoll.GetAll().Count().Should().Be(1);
        }

        [Test]
        public void ShouldGetInstance_WhenSameIdRequested()
        {
            //Arrange
            var controllerTimedPoll = new ControllerTimedPoll();
            controllerTimedPoll.Start(new ControllerFactory(), new Input(), PollInterval);
            var firstResult = controllerTimedPoll.CreateOrGet(IndexKey);

            //Act
            var secondResult = controllerTimedPoll.CreateOrGet(IndexKey);
            
            //Assert
            firstResult.Index.Should().Be(IndexKey);
            secondResult.Index.Should().Be(IndexKey);
            controllerTimedPoll.GetAll().Count().Should().Be(1);
        }

        [Test]
        public void ShouldRemoveInstance()
        {
            //Arrange
            _controllerTimedPoll.Start(new ControllerFactory(), new Input(), PollInterval);
            _controllerTimedPoll.CreateOrGet(IndexKey);

            //Act
            var result = _controllerTimedPoll.Remove(IndexKey);
            
            //Assert
            result.Should().BeTrue();
            _controllerTimedPoll.GetAll().Any().Should().BeFalse();
        }

        [Test]
        public void ShouldReturnFalse_WhenRemoveAttemptToRemoveInstanceSecondTime()
        {
            //Arrange
            var controllerTimedPoll = new ControllerTimedPoll();
            controllerTimedPoll.Start(new ControllerFactory(), new Input(), PollInterval);
            controllerTimedPoll.CreateOrGet(IndexKey);
            var firstResult = controllerTimedPoll.Remove(IndexKey);

            //Act
            var secondResult = controllerTimedPoll.Remove(IndexKey);
            
            //Assert
            firstResult.Should().BeTrue();
            secondResult.Should().BeFalse();
            controllerTimedPoll.GetAll().Any().Should().BeFalse();
        }

        [Test]
        public void ShouldStopThread_WhenLastInstanceRemovedFromPoll()
        {
            //Arrange
            var input = new Input();
            var factory = new ControllerFactory();
            var controllerTimedPoll = new ControllerTimedPoll();
            var firstStart = controllerTimedPoll.Start(factory, input, PollInterval);
            var secondStart = controllerTimedPoll.Start(factory, input, PollInterval);
            controllerTimedPoll.CreateOrGet(IndexKey);
            var firstRemove = controllerTimedPoll.Remove(IndexKey);

            //Act
            var thirdStart = controllerTimedPoll.Start(factory, input, PollInterval);
            
            //Assert
            firstStart.Should().BeTrue();
            secondStart.Should().BeFalse();
            firstRemove.Should().BeTrue();
            thirdStart.Should().BeTrue();
            controllerTimedPoll.GetAll().Any().Should().BeFalse();
        }

        [Test]
        public void ShouldAbortThread_WhenThreadNotClosedWithinTenTimesPollInterval()
        {
            //Arrange
            const int expectedGetStateResult = 0;
            var controller = new Controller(IndexKey, _controllerTimedPoll);
            
            _controllerFactoryMock
                .Setup(_ => _.Create(IndexKey))
                .Returns(controller);

            _inputMock
                .Setup(_ => _.GetState(IndexKey, ref It.Ref<InputState>.IsAny))
                .Returns(expectedGetStateResult);

            var firstStart = _controllerTimedPoll.Start(_controllerFactoryMock.Object, _inputMock.Object, PollInterval);

            _controllerTimedPoll.CreateOrGet(IndexKey);

            //Act
            Thread.Sleep(PollInterval * 2);
            _controllerTimedPoll.Dispose();
            
            //Assert
            firstStart.Should().BeTrue();
            _controllerTimedPoll
                .Start(_controllerFactoryMock.Object, _inputMock.Object, PollInterval)
                .Should().BeTrue();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldReturnError_WhenPollingController_ThenRemoveFromPoll(bool shouldReturn)
        {
            //Arrange
            const int expectedGetStateResult = 1;
             var controllerTimedPoll = new ControllerTimedPoll();
            var controller = new Controller(IndexKey, controllerTimedPoll);
            
            _controllerFactoryMock
                .Setup(_ => _.Create(IndexKey))
                .Returns(controller);

            _inputMock
                .Setup(_ => _.GetState(IndexKey, ref It.Ref<InputState>.IsAny))
                .Returns(expectedGetStateResult);

            if (shouldReturn)
                controllerTimedPoll.OnPollError += OnPollError_ReturnTrue;
            else
                controllerTimedPoll.OnPollError += OnPollError_ReturnFalse;
            
            controllerTimedPoll.Start(_controllerFactoryMock.Object, _inputMock.Object, PollInterval);

            //Act
            controllerTimedPoll.CreateOrGet(IndexKey);
            Thread.Sleep(PollInterval * 2);
            
            //Assert
            controllerTimedPoll.GetAll().Any().Should().Be(!shouldReturn);
        }

        private static bool OnPollError_ReturnTrue(IController controller, int result)
        {
            return true;
        }

        private static bool OnPollError_ReturnFalse(IController controller, int result)
        {
            return false;
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(100)]
        public void ShouldVibrate(int expectedResult)
        {
            //Arrange
            _inputMock
                .Setup(_ => _.SetState(IndexKey, ref It.Ref<InputVibration>.IsAny))
                .Returns(expectedResult);

            _controllerTimedPoll
                .Start(new ControllerFactory(), _inputMock.Object, PollInterval);

            //Act
            var result = _controllerTimedPoll.Vibrate(IndexKey, new InputVibration());
            
            //Assert
            result.Should().Be(expectedResult);
        }
        
        [TearDown]
        public void TearDown()
        {
            _controllerTimedPoll.Dispose();
        }
    }
}
