using System.Text;
using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public class StateChangedEventArgs
    {
        public InputData CurrentState { get; set; }
        public InputData PreviousState { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Current {CurrentState.ToString()}");
            sb.AppendLine($"Previous {PreviousState.ToString()}");
            return sb.ToString();
        }
    }
}
