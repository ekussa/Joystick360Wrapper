using System.Collections.Generic;
using System.Threading;
using Joystick360Controller.Structs;

namespace Joystick360Controller.UnitTests
{
    public class BlockController : IController
    {
        private readonly int _intervalToBlockPoll;

        public BlockController(int intervalToBlockPoll)
        {
            _intervalToBlockPoll = intervalToBlockPoll;
        }
        
        public bool Poll(InputState inputState)
        {
            Thread.Sleep(_intervalToBlockPoll);
            return true;
        }

        public void Vibrate(double left, double right)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public int Index { get; }
        
        public void Set(IControllerEvents controllerEvents)
        {
            throw new System.NotImplementedException();
        }

        public void Set(IEnumerable<IControllerEvents> controllerEventsCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}