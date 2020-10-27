using System;
using System.Collections.Generic;
using Joystick360Controller.Driver;
using Joystick360Controller.Structs;

namespace Joystick360Controller
{
    public interface IControllerTimedPoll : IDisposable
    {
        bool Start(IControllerFactory factory, IInput input, int millisecondsInterval);

        IController CreateOrGet(int index);
        
        IEnumerable<IController> GetAll();

        bool Remove(int key);

        int Vibrate(int index, InputVibration vibration);
    }
}
