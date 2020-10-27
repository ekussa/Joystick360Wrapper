using System;
using System.Threading.Tasks;

namespace Joystick360Controller
{
    public static class EventHandlerExtension
    {
        public static void TaskInvoke(this EventHandler eventHandler, object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => eventHandler?.Invoke(sender, e));
        }

        public static void TaskInvoke<T>(this EventHandler<T> eventHandler, object sender, T e)
        {
            Task.Factory.StartNew(() => eventHandler?.Invoke(sender, e));
        }
    }
}
