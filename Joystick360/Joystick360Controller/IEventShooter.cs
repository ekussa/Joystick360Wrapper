using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public interface IEventShooter
    {
        void OnStateChanged(InputData previous, InputData current);
    }
}