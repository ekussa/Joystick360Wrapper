using System;
using System.Threading;
using Application;
using Joystick360Controller;
using Joystick360Controller.Driver;

namespace Joystick360
{
    internal static class Program
    {
        private const string ConsoleDebugKey = "ConsoleDebug";
        private const string DebugDebugKey = "DebugDebug";
        private const string MouseKey = "HumanPointer";
        private const string BeepDigitalPadKey = "BeepDigitalPad";
        
        private static void Main()
        {
            Console.WriteLine("XBox controller 1 events handler");

            var debugEveryInputViaConsoleOutput = new DebugEveryInputViaConsoleOutput();
            var debugEveryInputViaDebugOutput = new DebugEveryInputViaDebugOutput();
            var mouseControllableFromBothSticks = new MouseControllableFromBothSticks();
            var digitalPadBeepWhenChanged = new DigitalPadBeepWhenChanged();
            
            var eventsRepository = new NamedAndCreatableEventsRepository();
            eventsRepository.Create(ConsoleDebugKey, debugEveryInputViaConsoleOutput);
            eventsRepository.Create(DebugDebugKey, debugEveryInputViaDebugOutput);
            eventsRepository.Create(MouseKey, mouseControllableFromBothSticks);
            eventsRepository.Create(BeepDigitalPadKey, digitalPadBeepWhenChanged);
            
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
            }
        }
    }
}
