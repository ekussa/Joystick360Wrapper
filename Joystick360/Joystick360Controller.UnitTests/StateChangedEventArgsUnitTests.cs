using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Joystick360Controller.UnitTests
{
    [TestFixture]
    public class StateChangedEventArgsUnitTests
    {
        [Test]
        public void ShouldTranslateToString()
        {
            //Arrange
            var starts = new List<string>
            {
                "Current ",
                "Previous ",
            };
            
            //Act
            var result = new StateChangedEventArgs().ToString();

            //Assert
            var split = result.Split(Environment.NewLine).ToList();
            split.All(_ => starts.Any(__ => __.StartsWith(_)));
        }
    }
}
