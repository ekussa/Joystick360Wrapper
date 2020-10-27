using System;
using FluentAssertions;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class PointUnitTests
    {
        private Point _pointMax;
        private Point _pointMin;

        public PointUnitTests()
        {
            _pointMax = new Point(int.MaxValue, int.MaxValue);
            _pointMin = new Point(int.MinValue, int.MinValue);
        }

        [Test]
        public void ShouldValidateProperties()
        {
            //Assert
            _pointMax.X.Should().Be(int.MaxValue);
            _pointMax.Y.Should().Be(int.MaxValue);
            
            _pointMin.X.Should().Be(int.MinValue);
            _pointMin.Y.Should().Be(int.MinValue);
        }
        
        [Test]
        public void ShouldCompare()
        {
            //Assert
            _pointMax.Equals(_pointMax).Should().BeTrue();
            _pointMax.Equals((object)_pointMax).Should().BeTrue();
            
            _pointMin.Equals(_pointMin).Should().BeTrue();
            _pointMin.Equals((object)_pointMin).Should().BeTrue();
            
            _pointMax.Equals(_pointMin).Should().BeFalse();
            _pointMax.Equals((object)_pointMin).Should().BeFalse();
            
            _pointMin.Equals(_pointMax).Should().BeFalse();
            _pointMin.Equals((object)_pointMax).Should().BeFalse();
        }
        
        [Test]
        public void ShouldCalculateHash()
        {
            //Assert
            _pointMax.GetHashCode().Should().NotBe(_pointMin.GetHashCode());
            _pointMin.GetHashCode().Should().NotBe(_pointMax.GetHashCode());
        }
    }
}