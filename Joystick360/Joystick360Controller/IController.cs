using System;
using System.Collections.Generic;

namespace Joystick360Controller
{
    public interface IController : IPollable, IControllerFeedBack, IDisposable
    {
        int Index { get; }
        void Set(IControllerEvents controllerEvents);
        void Set(IEnumerable<IControllerEvents> controllerEventsCollection);
    }
}
