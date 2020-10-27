using System;

namespace Joystick360Controller
{
    public interface IControllerEvents : IEventShooter
    {
        event EventHandler<StateChangedEventArgs> StateChanged;

        event EventHandler<bool> AChanged;
        event EventHandler APressed;
        event EventHandler AReleased;

        event EventHandler<bool> BChanged;
        event EventHandler BPressed;
        event EventHandler BReleased;

        event EventHandler<bool> XChanged;
        event EventHandler XPressed;
        event EventHandler XReleased;

        event EventHandler<bool> YChanged;
        event EventHandler YPressed;
        event EventHandler YReleased;

        event EventHandler<bool> StartChanged;
        event EventHandler StartPressed;
        event EventHandler StartReleased;
        
        event EventHandler<bool> BackChanged;
        event EventHandler BackPressed;
        event EventHandler BackReleased;

        event EventHandler<bool> RightShoulderChanged;
        event EventHandler RightShoulderPressed;
        event EventHandler RightShoulderReleased;

        event EventHandler<bool> LeftShoulderChanged;
        event EventHandler LeftShoulderPressed;
        event EventHandler LeftShoulderReleased;

        event EventHandler<bool> LeftStickButtonChanged;
        event EventHandler LeftStickButtonPressed;
        event EventHandler LeftStickButtonReleased;

        event EventHandler<bool> RightStickButtonChanged;
        event EventHandler RightStickButtonPressed;
        event EventHandler RightStickButtonReleased;
        
        event EventHandler<Point> LeftStickPositionChanged;
        event EventHandler<Point> RightStickPositionChanged;
        
        event EventHandler<DigitalPad> DigitalStickChanged;
        
        event EventHandler<byte> LeftTriggerPressureChanged;
        event EventHandler<byte> RightTriggerPressureChanged;
    }
}
