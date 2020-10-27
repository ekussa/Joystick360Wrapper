using System;
using System.Collections.Generic;
using System.Linq;
using Joystick360Controller.Driver;
using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public class Controller : IController
    {
        private readonly int _controllerIndex;

        private static IControllerTimedPoll _controllerTimedPoll;
        private List<IControllerEvents> _events;

        private InputState _previousState;

        public int Index => _controllerIndex;

        private Controller()
        {
        }
        
        public Controller(int index, IControllerTimedPoll timedPoll)
        {
            _previousState = new InputState();
            _controllerTimedPoll = timedPoll;
            _controllerIndex = index;
            _events = new List<IControllerEvents>();
        }

        public void Set(IControllerEvents controllerEvents)
        {
            _events = new List<IControllerEvents>{controllerEvents};
        }

        public void Set(IEnumerable<IControllerEvents> controllerEventsCollection)
        {
            _events = controllerEventsCollection.ToList();
        }
        
        public void Vibrate(double left, double right)
        {
            left = Math.Max(0d, Math.Min(1d, left));
            right = Math.Max(0d, Math.Min(1d, right));

            var vibration = new InputVibration
            {
                LeftMotorSpeed = (ushort)(ushort.MaxValue * left),
                RightMotorSpeed = (ushort)(ushort.MaxValue * right)
            };
            _controllerTimedPoll.Vibrate(_controllerIndex, vibration);
        }

        public override string ToString()
        {
            return _controllerIndex.ToString();
        }

        public bool Poll(InputState currentState)
        {
            if (currentState.Equals(_previousState)) return false;

            _events.ForEach(_ => _.OnStateChanged(_previousState.Data, currentState.Data));

            _previousState.Copy(currentState);

            return true;
        }

        public void Dispose()
        {
            _controllerTimedPoll.Remove(_controllerIndex);
        }
    }
}
