using FluentAssertions;
using Joystick360Controller.Structs;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    public class ConcreteControllerEventsUnitTestsAnalogical
    {
        private ConcreteControllerEvents _concreteControllerEvents;
        private InputData _currentState;
        private InputData _previousState;
        private byte _changedByte;
        private Point _changedPoint;

        [SetUp]
        public void Setup()
        {
            _concreteControllerEvents = new ConcreteControllerEvents();
            _currentState = new InputData();
            _previousState = new InputData();

            _changedByte = new byte();
        }
        
        private void ConcreteControllerEventsOnTriggerPressureChanged(object sender, byte e)
        {
            _changedByte = e;
        }

        [TestCase(0, 100)]
        [TestCase(100, 0)]
        public void ShouldRaiseChangeEvent_WhenLeftTriggerChanged(byte current, byte previous)
        {
            //Arrange
            _concreteControllerEvents.LeftTriggerPressureChanged += ConcreteControllerEventsOnTriggerPressureChanged;
            _previousState.bLeftTrigger = previous;
            _currentState.bLeftTrigger = current;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _changedByte.Should().Be(current);
        }
        
        [TestCase(0, 100)]
        [TestCase(100, 0)]
        public void ShouldRaiseChangeEvent_WhenRightTriggerChanged(byte current, byte previous)
        {
            //Arrange
            _concreteControllerEvents.RightTriggerPressureChanged += ConcreteControllerEventsOnTriggerPressureChanged;
            _previousState.bRightTrigger = previous;
            _currentState.bRightTrigger = current;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _changedByte.Should().Be(current);
        }
        
        private void ConcreteControllerEventsOnLeftStickPositionChanged(object sender, Point e)
        {
            _changedPoint = e;
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void ShouldRaiseChangeEvent_WhenLeftStickChanged(short current, short previous)
        {
            //Arrange
            _concreteControllerEvents.LeftStickPositionChanged += ConcreteControllerEventsOnLeftStickPositionChanged;
            _previousState.sThumbLY = previous;
            _currentState.sThumbLY = current;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _changedPoint.Should().NotBeNull();
        }
        
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void ShouldRaiseChangeEvent_WhenRightStickChanged2(short current, short previous)
        {
            //Arrange
            _concreteControllerEvents.RightStickPositionChanged += ConcreteControllerEventsOnLeftStickPositionChanged;
            _previousState.sThumbRX = previous;
            _currentState.sThumbRX = current;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _changedPoint.Should().NotBeNull();
        }
    }
}
