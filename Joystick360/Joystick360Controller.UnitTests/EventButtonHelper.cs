using System;
using System.Threading;

namespace Joystick360Controller.UnitTests
{
    public class EventButtonHelper<T>
    {
        private readonly ManualResetEventSlim _changeEvent;
        private readonly ManualResetEventSlim _pressEvent;
        private readonly ManualResetEventSlim _releaseEvent;

        public T Tag { get; set; }
        
        public EventButtonHelper()
        {
            _changeEvent = new ManualResetEventSlim(false);
            _pressEvent = new ManualResetEventSlim(false);
            _releaseEvent = new ManualResetEventSlim(false);
        }

        public void SetChanged()
        {
            _changeEvent.Set();
        }

        public bool WaitChanged(TimeSpan timeout)
        {
            return _changeEvent.Wait(timeout);
        }
        
        public void SetPressed()
        {
            _pressEvent.Set();
        }

        public bool PressedSet()
        {
            return _pressEvent.IsSet;
        }

        private bool WaitPressed(TimeSpan timeout)
        {
            return _pressEvent.Wait(timeout);
        }
        
        public void SetReleased()
        {
            _releaseEvent.Set();
        }

        public bool ReleaseSet()
        {
            return _releaseEvent.IsSet;
        }

        private bool WaitRelease(TimeSpan timeout)
        {
            return _releaseEvent.Wait(timeout);
        }

        public bool WaitChangedAndPress(TimeSpan timeout)
        {
            return WaitChanged(timeout) && WaitPressed(timeout);
        }
        
        public bool WaitChangedAndRelease(TimeSpan timeout)
        {
            return WaitChanged(timeout) && WaitRelease(timeout);
        }
    }
}
