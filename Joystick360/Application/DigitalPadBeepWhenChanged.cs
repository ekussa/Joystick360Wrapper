using System;
using Joystick360Controller;

namespace Application
{
    public class DigitalPadBeepWhenChanged : ICreatableEvents
    {
        public IControllerEvents DumpEvents()
        {
            var controller = new ConcreteControllerEvents();

            controller.DigitalStickChanged += ControllerOnDigitalStickChanged;
            
            return controller;
        }

        private static void ControllerOnDigitalStickChanged(object sender, DigitalPad e)
        {
            Console.Beep(1000, 100);
        }
    }
}