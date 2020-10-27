using System;
using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public class ConcreteControllerEvents : IControllerEvents
    {
        public event EventHandler<StateChangedEventArgs> StateChanged;
        public event EventHandler<bool> AChanged;
        public event EventHandler APressed;
        public event EventHandler AReleased;
        public event EventHandler<bool> BChanged;
        public event EventHandler BPressed;
        public event EventHandler BReleased;
        public event EventHandler<bool> XChanged;
        public event EventHandler XPressed;
        public event EventHandler XReleased;
        public event EventHandler<bool> YChanged;
        public event EventHandler YPressed;
        public event EventHandler YReleased;
        public event EventHandler<bool> StartChanged;
        public event EventHandler StartPressed;
        public event EventHandler StartReleased;
        public event EventHandler<bool> BackChanged;
        public event EventHandler BackPressed;
        public event EventHandler BackReleased;
        public event EventHandler<bool> RightShoulderChanged;
        public event EventHandler RightShoulderPressed;
        public event EventHandler RightShoulderReleased;
        public event EventHandler<bool> LeftShoulderChanged;
        public event EventHandler LeftShoulderPressed;
        public event EventHandler LeftShoulderReleased;
        public event EventHandler<bool> LeftStickButtonChanged;
        public event EventHandler LeftStickButtonPressed;
        public event EventHandler LeftStickButtonReleased;
        public event EventHandler<bool> RightStickButtonChanged;
        public event EventHandler RightStickButtonPressed;
        public event EventHandler RightStickButtonReleased;
        public event EventHandler<Point> LeftStickPositionChanged;
        public event EventHandler<Point> RightStickPositionChanged;
        public event EventHandler<DigitalPad> DigitalStickChanged;
        public event EventHandler<byte> LeftTriggerPressureChanged;
        public event EventHandler<byte> RightTriggerPressureChanged;
        
        public void OnStateChanged(InputData prev, InputData cur)
        {
            StateChanged.TaskInvoke(this,
                new StateChangedEventArgs
                {
                    CurrentState = cur,
                    PreviousState = prev,
                });

            if(prev.IsAPressed ^ cur.IsAPressed)
            {
                AChanged.TaskInvoke(this, cur.IsAPressed);
                if (!prev.IsAPressed && cur.IsAPressed)
                    APressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsAPressed && !cur.IsAPressed)
                    AReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsBPressed ^ cur.IsBPressed)
            {
                BChanged.TaskInvoke(this, cur.IsBPressed);
                if (!prev.IsBPressed && cur.IsBPressed)
                    BPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsBPressed && !cur.IsBPressed)
                    BReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsXPressed ^ cur.IsXPressed)
            {
                XChanged.TaskInvoke(this, cur.IsXPressed);
                if (!prev.IsXPressed && cur.IsXPressed)
                    XPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsXPressed && !cur.IsXPressed)
                    XReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsYPressed ^ cur.IsYPressed)
            {
                YChanged.TaskInvoke(this, cur.IsYPressed);
                if (!prev.IsYPressed && cur.IsYPressed)
                    YPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsYPressed && !cur.IsYPressed)
                    YReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsStartPressed ^ cur.IsStartPressed)
            {
                StartChanged.TaskInvoke(this, cur.IsStartPressed);
                if (!prev.IsStartPressed && cur.IsStartPressed)
                    StartPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsStartPressed && !cur.IsStartPressed)
                    StartReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsBackPressed ^ cur.IsBackPressed)
            {
                BackChanged.TaskInvoke(this, cur.IsBackPressed);
                if (!prev.IsBackPressed && cur.IsBackPressed)
                    BackPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsBackPressed && !cur.IsBackPressed)
                    BackReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsRightShoulderPressed ^ cur.IsRightShoulderPressed)
            {
                RightShoulderChanged.TaskInvoke(this, cur.IsRightShoulderPressed);
                if (!prev.IsRightShoulderPressed && cur.IsRightShoulderPressed)
                    RightShoulderPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsRightShoulderPressed && !cur.IsRightShoulderPressed)
                    RightShoulderReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsLeftShoulderPressed ^ cur.IsLeftShoulderPressed)
            {
                LeftShoulderChanged.TaskInvoke(this, cur.IsLeftShoulderPressed);
                if (!prev.IsLeftShoulderPressed && cur.IsLeftShoulderPressed)
                    LeftShoulderPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsLeftShoulderPressed && !cur.IsLeftShoulderPressed)
                    LeftShoulderReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsRightStickPressed ^ cur.IsRightStickPressed)
            {
                RightStickButtonChanged.TaskInvoke(this, cur.IsRightStickPressed);
                if (!prev.IsRightStickPressed && cur.IsRightStickPressed)
                    RightStickButtonPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsRightStickPressed && !cur.IsRightStickPressed)
                    RightStickButtonReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if(prev.IsLeftStickPressed ^ cur.IsLeftStickPressed)
            {
                LeftStickButtonChanged.TaskInvoke(this, cur.IsLeftStickPressed);
                if (!prev.IsLeftStickPressed && cur.IsLeftStickPressed)
                    LeftStickButtonPressed.TaskInvoke(this, EventArgs.Empty);
                else if (prev.IsLeftStickPressed && !cur.IsLeftStickPressed)
                    LeftStickButtonReleased.TaskInvoke(this, EventArgs.Empty);
            }

            if (DigitalStickChanged != null)
                if (!prev.GetDigitalPad.Equals(cur.GetDigitalPad))
                    DigitalStickChanged.Invoke(this, cur.GetDigitalPad);
            
            if (RightTriggerPressureChanged != null)
                if(prev.RightTriggerPressure != cur.RightTriggerPressure)
                    RightTriggerPressureChanged.Invoke(this, cur.RightTriggerPressure);

            if (LeftTriggerPressureChanged != null)
                if(prev.LeftTriggerPressure != cur.LeftTriggerPressure)
                    LeftTriggerPressureChanged.Invoke(this, cur.LeftTriggerPressure);

            if (RightStickPositionChanged != null)
                if(!prev.RightThumbStickPosition.Equals(cur.RightThumbStickPosition))
                    RightStickPositionChanged.Invoke(this, cur.RightThumbStickPosition);
            
            if (LeftStickPositionChanged != null)
                if(!prev.LeftThumbStickPosition.Equals(cur.LeftThumbStickPosition))
                    LeftStickPositionChanged.Invoke(this, cur.LeftThumbStickPosition);
        }
    }
}
