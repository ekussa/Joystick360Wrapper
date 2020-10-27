using System;
using System.Threading;
using Application;
using Joystick360Controller;
using Joystick360Controller.Driver;

namespace JoystickMouse
{
    internal static class Program
    {
        private const string ConsoleDebugKey = "ConsoleDebug";
        private const string MouseKey = "HumanPointer";

        private static void Main()
        {
            Console.WriteLine("XBox controller 1 events handler");

            var debugEveryInputViaConsoleOutput = new DebugEveryInputViaConsoleOutput();
            var mouseControllableFromBothSticks = new MouseControllableFromBothSticks();
            
            var eventsRepository = new NamedAndCreatableEventsRepository();
            eventsRepository.Create(ConsoleDebugKey, debugEveryInputViaConsoleOutput);
            eventsRepository.Create(MouseKey, mouseControllableFromBothSticks);

            var factory = new ControllerFactory();
            var poll = new ControllerTimedPoll();

            factory.Setup(new ControllerFactoryArguments { ControllerTimedPoll = poll, });
            poll.Start(factory, new Input(), 25);
            
            using (var controller = poll.CreateOrGet(0))
            {
                controller.Set(eventsRepository.GetAll());
                
                controller.Vibrate(10, 10);
                Thread.Sleep(100);
                controller.Vibrate(0, 0);
                
                Console.WriteLine("Press any key to terminate");
                Console.ReadKey();

                controller.Vibrate(10, 10);
                Thread.Sleep(1000);
                controller.Vibrate(0, 0);
            }
        }
    }
}
