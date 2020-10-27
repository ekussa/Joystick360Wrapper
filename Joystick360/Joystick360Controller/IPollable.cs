using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public interface IPollable
    {
        bool Poll(InputState inputState);
    }
}