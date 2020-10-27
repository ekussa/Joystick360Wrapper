using FluentAssertions;
using Joystick360Controller.Driver;
using Joystick360Controller.Structs;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class InputUnitTests
    {
        [Test]
        public void ShouldReturnError_WhenInvalidIndexStatusGiven_GetState()
        {
            //Arrange
            var input = new Input();
            var inputState = new InputState();
            
            //Act
            var result = input.GetState(99, ref inputState);
            
            //Assert
            result.Should().Be(160);
        }
        
        [Test]
        public void ShouldReturnError_WhenInvalidIndexStatusGiven_InputVibration()
        {
            //Arrange
            var input = new Input();
            var inputVibration = new InputVibration();
            
            //Act
            var result = input.SetState(99, ref inputVibration);
            
            //Assert
            result.Should().Be(160);
        }
        
        [Test]
        public void ShouldReturnError_WhenInvalidIndexStatusGiven_GetCapabilities()
        {
            //Arrange
            var input = new Input();
            var inputCapabilities = new InputCapabilities();
            
            //Act
            var result = input.GetCapabilities(99, 0, ref inputCapabilities);
            
            //Assert
            result.Should().Be(160);
        }
        
        [Test]
        public void ShouldReturnError_WhenInvalidIndexStatusGiven_GetBatteryInformation()
        {
            //Arrange
            var input = new Input();
            var inputBatteryInformation = new InputBatteryInformation();
            
            //Act
            var result = input.GetBatteryInformation(99, 0, ref inputBatteryInformation);
            
            //Assert
            result.Should().Be(160);
        }
    }
}