using System;
using System.Collections.Generic;
using FluentAssertions;
using Joystick360Controller.Constants;
using Joystick360Controller.Structs;
using Moq;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class ControllerUnitTests
    {
        private const int Index1 = 1;
        private const int Index2 = 2;
        private const int Index3 = 3;
        
        private Mock<IControllerTimedPoll> _controllerTimedPollMock;
        private Controller _controller;
        private EventButtonHelper<bool> _eventButtonHelper;
        private readonly TimeSpan _timeout;

        public ControllerUnitTests()
        {
            _timeout = TimeSpan.FromMilliseconds(100);
        }
        
        [SetUp]
        public void Setup()
        {
            _eventButtonHelper = new EventButtonHelper<bool>();
            _controllerTimedPollMock = new Mock<IControllerTimedPoll>(MockBehavior.Strict);
            _controller = new Controller(Index1, _controllerTimedPollMock.Object);
        }
        
        [Test]
        public void ShouldBeConstructedWithIndex()
        {
            //Assert
            _controller.Index.Should().Be(Index1);
        }

        [TestCase(Index1)]
        [TestCase(Index2)]
        [TestCase(Index3)]
        public void ShouldConstructWithProperIndex(int index)
        {
            //Arrange & act
            var controller = new Controller(index, new ControllerTimedPoll());
            
            //Assert
            controller.Index.Should().Be(index);
        }
        
        [Test]
        public void ShouldFireEventAndReturnPollDidFireEvents_WhenSingleEventSetAndInputStateChanged()
        {
            //Arrange
            var concreteControllerEvents1 = new ConcreteControllerEvents();
            concreteControllerEvents1.AChanged += ShouldSetAndFireEvent_ConcreteControllerEventsOnButtonChanged1;
            
            //Act
            _controller.Set(concreteControllerEvents1);
            
            //Assert
            var state = new InputState {Data = new InputData {wButtons = (ushort) ButtonFlags.A}};
            _controller.Poll(state).Should().BeTrue();
            _eventButtonHelper.WaitChanged(_timeout).Should().BeTrue();
        }

        [Test]
        public void ShouldFireEventAndReturnPollDidFireEvents_WhenMultipleEventSetAndInputStateChanged()
        {
            //Arrange
            var concreteControllerEvents1 = new ConcreteControllerEvents();
            concreteControllerEvents1.AChanged += ShouldSetAndFireEvent_ConcreteControllerEventsOnButtonChanged1;
            var concreteControllerEvents2 = new ConcreteControllerEvents();
            concreteControllerEvents2.AChanged += ShouldSetAndFireEvent_ConcreteControllerEventsOnButtonChanged2;
            
            //Act
            _controller.Set(new List<IControllerEvents>
            {
                concreteControllerEvents1,
                concreteControllerEvents2,
            });
            
            //Assert
            var state = new InputState {Data = new InputData {wButtons = (ushort) ButtonFlags.A}};
            _controller.Poll(state).Should().BeTrue();
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
        }
        
        [Test]
        public void ShouldReturnPollDidFireEvents_WhenNoEventSet()
        {
            //Assert
            var state = new InputState {Data = new InputData {wButtons = (ushort) ButtonFlags.A}};
            _controller.Poll(state).Should().BeTrue();
        }
        
        [Test]
        public void ShouldReturnPollDidntFireEvents_WhenNoEventSetAndNoInputStateChanged()
        {
            //Assert
            _controller.Poll(new InputState()).Should().BeFalse();
        }

        private void ShouldSetAndFireEvent_ConcreteControllerEventsOnButtonChanged2(object sender, bool e)
        {
            _eventButtonHelper.SetPressed();
        }

        private void ShouldSetAndFireEvent_ConcreteControllerEventsOnButtonChanged1(object sender, bool e)
        {
            _eventButtonHelper.SetChanged();
        }
        
        [Test]
        public void ShouldRemoveFromPoll_WhenDisposed()
        {
            //Arrange
            _controllerTimedPollMock
                .Setup(_ => _.Remove(Index1))
                .Returns(true);
            
            //Act
            _controller.Dispose();
            
            //Assert
            _controllerTimedPollMock.VerifyAll();
        }
        
        [Test]
        public void ShouldGetIndexAsString_WhenToStringRan()
        {
            //Act
            var result = _controller.ToString();
            
            //Assert
            result.Should().Be(Index1.ToString());
        }
        
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(float.MaxValue, float.MaxValue)]
        [TestCase(float.MinValue, float.MinValue)]
        [TestCase(float.MaxValue, float.MinValue)]
        [TestCase(float.MaxValue, float.MinValue)]
        //TODO: enhance calculation assertions
        public void ShouldForwardVibrateCall(float leftMotor, float rightMotor)
        {
            //Arrange
            _controllerTimedPollMock
                .Setup(_ => _.Vibrate(Index1, It.IsAny<InputVibration>()))
                .Returns(0);
            
            //Act
            _controller.Vibrate(leftMotor, rightMotor);
            
            //Assert
            _controllerTimedPollMock.VerifyAll();
        }
    }
}
