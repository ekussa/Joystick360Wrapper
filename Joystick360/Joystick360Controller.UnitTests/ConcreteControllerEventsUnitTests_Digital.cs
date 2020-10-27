using System;
using FluentAssertions;
using Joystick360Controller.Constants;
using Joystick360Controller.Structs;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class ConcreteControllerEventsUnitTestsDigital
    {
        private TimeSpan _timeout;
        private InputData _currentState;
        private InputData _previousState;
        private DigitalPad _digitalPadChange;
        private EventButtonHelper<bool> _eventButtonHelper;
        private ConcreteControllerEvents _concreteControllerEvents;

        [SetUp]
        public void Setup()
        {
            _concreteControllerEvents = new ConcreteControllerEvents();
            _currentState = new InputData();
            _previousState = new InputData();

            _timeout = TimeSpan.FromMilliseconds(100);
            _eventButtonHelper = new EventButtonHelper<bool>();
            _digitalPadChange = null;
        }
        
        [Test]
        public void ShouldNotThrowException_WhenNoEventHandlerSet()
        {
            //Act
            _concreteControllerEvents.OnStateChanged(_currentState, _currentState );
        }
        
        private void ConcreteControllerEventsOnStateChanged_ShouldMatchStates(object sender, StateChangedEventArgs e)
        {
            e.CurrentState.Should().Be(_currentState);
            e.PreviousState.Should().Be(_previousState);
            _eventButtonHelper.SetChanged();
        }

        [Test]
        public void ShouldRaiseStateChangedEvent()
        {
            //Arrange
            _concreteControllerEvents.StateChanged += ConcreteControllerEventsOnStateChanged_ShouldMatchStates;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);
            
            //Assert
            _eventButtonHelper.WaitChanged(_timeout).Should().BeTrue();
        }
        
        private void ConcreteControllerEventsOnButtonChanged(object sender, bool e)
        {
            _eventButtonHelper.SetChanged();
            _eventButtonHelper.Tag = e;
        }

        private void ConcreteControllerEventsOnButtonPressed(object sender, EventArgs e)
        {
            _eventButtonHelper.SetPressed();
        }

        private void ConcreteControllerEventsOnButtonRelease(object sender, EventArgs e)
        {
            _eventButtonHelper.SetReleased();
        }

        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenAPressed()
        {
            //Arrange
            _concreteControllerEvents.AChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.APressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.AReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.A;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenAReleased()
        {
            //Arrange
            _concreteControllerEvents.AChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.APressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.AReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.A;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenBPressed()
        {
            //Arrange
            _concreteControllerEvents.BChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.BPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.BReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.B;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenBReleased()
        {
            //Arrange
            _concreteControllerEvents.BChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.BPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.BReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.B;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenXPressed()
        {
            //Arrange
            _concreteControllerEvents.XChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.XPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.XReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.X;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenXReleased()
        {
            //Arrange
            _concreteControllerEvents.XChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.XPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.XReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.X;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenYPressed()
        {
            //Arrange
            _concreteControllerEvents.YChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.YPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.YReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.Y;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenYReleased()
        {
            //Arrange
            _concreteControllerEvents.YChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.YPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.YReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Y;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenStartPressed()
        {
            //Arrange
            _concreteControllerEvents.StartChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.StartPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.StartReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.Start;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenStartReleased()
        {
            //Arrange
            _concreteControllerEvents.StartChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.StartPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.StartReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Start;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenBackPressed()
        {
            //Arrange
            _concreteControllerEvents.BackChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.BackPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.BackReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.Back;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenBackReleased()
        {
            //Arrange
            _concreteControllerEvents.BackChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.BackPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.BackReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Back;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenLeftStickPressed()
        {
            //Arrange
            _concreteControllerEvents.LeftStickButtonChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.LeftStickButtonPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.LeftStickButtonReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.LeftThumb;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenLeftStickReleased()
        {
            //Arrange
            _concreteControllerEvents.LeftStickButtonChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.LeftStickButtonPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.LeftStickButtonReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.LeftThumb;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenRightStickPressed()
        {
            //Arrange
            _concreteControllerEvents.RightStickButtonChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.RightStickButtonPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.RightStickButtonReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.RightThumb;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenRightStickReleased()
        {
            //Arrange
            _concreteControllerEvents.RightStickButtonChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.RightStickButtonPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.RightStickButtonReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.RightThumb;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenLeftShoulderPressed()
        {
            //Arrange
            _concreteControllerEvents.LeftShoulderChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.LeftShoulderPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.LeftShoulderReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.LeftShoulder;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenLeftShoulderReleased()
        {
            //Arrange
            _concreteControllerEvents.LeftShoulderChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.LeftShoulderPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.LeftShoulderReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.LeftShoulder;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndPressed_WhenRightShoulderPressed()
        {
            //Arrange
            _concreteControllerEvents.RightShoulderChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.RightShoulderPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.RightShoulderReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.Zero;
            _currentState.wButtons = (ushort)ButtonFlags.RightShoulder;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndPress(_timeout).Should().BeTrue();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeTrue();
        }
        
        [Test]
        public void ShouldRaiseChangeEventAndReleased_WhenRightShoulderReleased()
        {
            //Arrange
            _concreteControllerEvents.RightShoulderChanged += ConcreteControllerEventsOnButtonChanged;
            _concreteControllerEvents.RightShoulderPressed += ConcreteControllerEventsOnButtonPressed; 
            _concreteControllerEvents.RightShoulderReleased += ConcreteControllerEventsOnButtonRelease; 
            _previousState.wButtons = (ushort)ButtonFlags.RightShoulder;
            _currentState.wButtons = (ushort)ButtonFlags.Zero;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChangedAndRelease(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.Tag.Should().BeFalse();
        }
        
        [TestCase(ButtonFlags.Zero, ButtonFlags.DigitalPadUp)]
        [TestCase(ButtonFlags.DigitalPadUp, ButtonFlags.Zero)]
        [TestCase(ButtonFlags.Zero, ButtonFlags.DigitalPadDown)]
        [TestCase(ButtonFlags.DigitalPadDown, ButtonFlags.Zero)]
        [TestCase(ButtonFlags.Zero, ButtonFlags.DigitalPadRight)]
        [TestCase(ButtonFlags.DigitalPadRight, ButtonFlags.Zero)]
        [TestCase(ButtonFlags.Zero, ButtonFlags.DigitalPadLeft)]
        [TestCase(ButtonFlags.DigitalPadLeft, ButtonFlags.Zero)]
        public void ShouldRaiseChangeEvent_WhenDigitalPadChanged(ButtonFlags current, ButtonFlags previous)
        {
            //Arrange
            _concreteControllerEvents.DigitalStickChanged += ConcreteControllerEventsOnDigitalStickChanged;
            _previousState.wButtons = (ushort)previous;
            _currentState.wButtons = (ushort)current;
            
            //Act
            _concreteControllerEvents.OnStateChanged(_previousState, _currentState);

            //Assert
            _eventButtonHelper.WaitChanged(_timeout).Should().BeTrue();
            _eventButtonHelper.PressedSet().Should().BeFalse();
            _eventButtonHelper.ReleaseSet().Should().BeFalse();
            _digitalPadChange.Should().NotBeNull();
        }

        private void ConcreteControllerEventsOnDigitalStickChanged(object sender, DigitalPad e)
        {
            _digitalPadChange = e;
            _eventButtonHelper.SetChanged();
        }
    }
}
