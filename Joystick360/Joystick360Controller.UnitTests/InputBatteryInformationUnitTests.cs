using FluentAssertions;
using Joystick360Controller.Constants;
using Joystick360Controller.Structs;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class InputBatteryInformationUnitTests
    {
        [TestCase((byte)BatteryTypes.Wired, (byte)BatteryLevel.Full, "Wired Full")]
        [TestCase((byte)BatteryTypes.Alkaline, (byte)BatteryLevel.Empty, "Alkaline Empty")]
        [TestCase((byte)BatteryTypes.Nimh, (byte)BatteryLevel.Low, "Nimh Low")]
        [TestCase((byte)BatteryTypes.Unknown, (byte)BatteryLevel.Medium, "Unknown Medium")]
        [TestCase((byte)BatteryTypes.Disconnected, (byte)BatteryLevel.Medium, "Disconnected Medium")]
        public void ShouldConvertToStringEveryState(byte batteryTypes, byte batteryLevel, string expectedResult)
        {
            //Arrange
            var inputBatteryInformation = new InputBatteryInformation
            {
                BatteryLevel = batteryLevel,
                BatteryType = batteryTypes,
            };

            //Act
            var result = inputBatteryInformation.ToString();

            //Assert
            result.Should().Be(expectedResult);
        }
    }
}
