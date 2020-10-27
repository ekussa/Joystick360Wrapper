using FluentAssertions;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class DigitalPadUnitTests
    {
        private readonly DigitalPad _digitalPadFalse;
        private readonly DigitalPad _digitalPadTrue;
        
        public DigitalPadUnitTests()
        {
            _digitalPadTrue = new DigitalPad(true, true, true, true);
            _digitalPadFalse = new DigitalPad(false, false, false, false);
        }
        
        [TestCase(false, false, false, false, "")]
        [TestCase(true, false, false, false, "Up")]
        [TestCase(false, true, false, false, "Down")]
        [TestCase(false, false, true, false, "Left")]
        [TestCase(false, false, false, true, "Right")]
        [TestCase(true, true, true, true, "Up Down Left Right")]
        public void ShouldGetString(bool up, bool down, bool left, bool right, string expected)
        {
            //Arrange
            var digitalPad = new DigitalPad(up, down, left, right);
            
            //Act
            var result = digitalPad.ToString();

            //Assert
            result.Should().Be(expected);
        }

        [Test]
        public void ShouldGetStates()
        {
            //Assert
            _digitalPadTrue.Up.Should().BeTrue();
            _digitalPadTrue.Down.Should().BeTrue();
            _digitalPadTrue.Left.Should().BeTrue();
            _digitalPadTrue.Right.Should().BeTrue();
            
            _digitalPadFalse.Up.Should().BeFalse();
            _digitalPadFalse.Down.Should().BeFalse();
            _digitalPadFalse.Left.Should().BeFalse();
            _digitalPadFalse.Right.Should().BeFalse();
        }
        
        [Test]
        public void ShouldCompare()
        {
            //Act & Assert
            _digitalPadTrue.Equals(_digitalPadTrue).Should().BeTrue();
            _digitalPadTrue.Equals((object)_digitalPadTrue).Should().BeTrue();

            _digitalPadFalse.Equals(_digitalPadFalse).Should().BeTrue();
            _digitalPadFalse.Equals((object)_digitalPadFalse).Should().BeTrue();

            _digitalPadTrue.Equals(_digitalPadFalse).Should().BeFalse();
            _digitalPadTrue.Equals((object)_digitalPadFalse).Should().BeFalse();

            _digitalPadFalse.Equals(_digitalPadTrue).Should().BeFalse();
            _digitalPadFalse.Equals((object)_digitalPadTrue).Should().BeFalse();
        }
        
        [Test]
        public void ShouldGetHash()
        {
            //Assert
            _digitalPadTrue.GetHashCode().Should().NotBe(_digitalPadFalse.GetHashCode());
            _digitalPadFalse.GetHashCode().Should().NotBe(_digitalPadTrue.GetHashCode());
        }
    }
}
