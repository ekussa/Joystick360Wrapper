using FluentAssertions;
using Joystick360Controller.Structs;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class InputStateUnitTests
    {
        private readonly InputState _inputStateMax;
        private readonly InputState _inputStateMin;

        public InputStateUnitTests()
        {
            _inputStateMax = new InputState
            {
                PacketNumber = int.MaxValue,
                Data = new InputData
                {
                    wButtons = ushort.MaxValue,
                    bLeftTrigger = byte.MaxValue,
                    bRightTrigger = byte.MaxValue,
                    sThumbLX = short.MaxValue,
                    sThumbLY = short.MaxValue,
                    sThumbRX = short.MaxValue,
                    sThumbRY = short.MaxValue,
                },
            };
            
            _inputStateMin = new InputState
            {
                PacketNumber = int.MinValue,
                Data = new InputData
                {
                    wButtons = ushort.MinValue,
                    bLeftTrigger = byte.MinValue,
                    bRightTrigger = byte.MinValue,
                    sThumbLX = short.MinValue,
                    sThumbLY = short.MinValue,
                    sThumbRX = short.MinValue,
                    sThumbRY = short.MinValue,
                },
            };
        }
        
        [Test]
        public void ShouldCopyMin()
        {
            //Act
            var result = new InputState();
            result.Copy(_inputStateMin);
            
            //Assert
            ShouldAssertEqual(result, _inputStateMin);
        }

        [Test]
        public void ShouldCopyMax()
        {
            //Act
            var result = new InputState();
            result.Copy(_inputStateMax);
            
            //Assert
            ShouldAssertEqual(result, _inputStateMax);
        }

        private static void ShouldAssertEqual(InputState inputStateA, InputState inputStateB)
        {
            inputStateA.PacketNumber.Should().Be(inputStateB.PacketNumber);
            inputStateA.Data.wButtons.Should().Be(inputStateB.Data.wButtons);
            inputStateA.Data.sThumbLX.Should().Be(inputStateB.Data.sThumbLX);
            inputStateA.Data.sThumbLY.Should().Be(inputStateB.Data.sThumbLY);
            inputStateA.Data.sThumbRX.Should().Be(inputStateB.Data.sThumbRX);
            inputStateA.Data.sThumbRY.Should().Be(inputStateB.Data.sThumbRY);
            inputStateA.Data.bLeftTrigger.Should().Be(inputStateB.Data.bLeftTrigger);
            inputStateA.Data.bRightTrigger.Should().Be(inputStateB.Data.bRightTrigger);
        }

        [Test]
        public void ShouldNotBeEqual()
        {
            //Assert
            _inputStateMax.Equals(_inputStateMin).Should().BeFalse();
            _inputStateMax.Equals((object)_inputStateMin).Should().BeFalse();
        }
        
        [Test]
        public void ShouldBeEqual()
        {
            //Assert
            _inputStateMax.Equals(_inputStateMax).Should().BeTrue();
            _inputStateMax.Equals((object)_inputStateMax).Should().BeTrue();
            _inputStateMin.Equals(_inputStateMin).Should().BeTrue();
            _inputStateMin.Equals((object)_inputStateMin).Should().BeTrue();
        }
        
        [Test]
        public void ShouldBeGetHash()
        {
            //Assert
            _inputStateMax.GetHashCode().Should().NotBe(_inputStateMin.GetHashCode());
            _inputStateMax.GetHashCode().Should().Be(_inputStateMax.GetHashCode());
            _inputStateMin.GetHashCode().Should().Be(_inputStateMin.GetHashCode());
        }
    }
}
