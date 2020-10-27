using System;
using Joystick360Controller;

namespace Application
{
    public class DebugEveryInputViaConsoleOutput : ICreatableEvents
    {
        public IControllerEvents DumpEvents()
        {
            var controller = new ConcreteControllerEvents();
            
            controller.StateChanged += ControllerOnStateChanged;

            controller.AChanged += ControllerOnAChanged;
            controller.APressed += ControllerOnAPressed;
            controller.AReleased += ControllerOnAReleased;
            
            controller.BChanged += ControllerOnBChanged;
            controller.BPressed += ControllerOnBPressed;
            controller.BackReleased += ControllerOnBackReleased;
            
            controller.XChanged += ControllerOnXChanged;
            controller.XPressed += ControllerOnXPressed;
            controller.XReleased += ControllerOnXReleased;
            
            controller.YChanged += ControllerOnYChanged;
            controller.YPressed += ControllerOnYPressed;
            controller.YReleased += ControllerOnYReleased;
            
            controller.StartChanged += ControllerOnStartChanged;
            controller.StartPressed += ControllerOnStartPressed;
            controller.StartReleased += ControllerOnStartReleased;
            
            controller.BackChanged += ControllerOnBackChanged;
            controller.BackPressed += ControllerOnBackPressed;
            controller.BackReleased += ControllerOnBackReleased;
            
            controller.LeftStickButtonPressed += ControllerOnLeftStickButtonPressed;
            controller.LeftStickButtonReleased += ControllerOnLeftStickButtonReleased;
            
            controller.RightStickButtonPressed += ControllerOnRightStickButtonPressed;
            controller.RightStickButtonReleased += ControllerOnRightStickButtonReleased;

            controller.DigitalStickChanged += ControllerOnDigitalStickChanged;

            controller.LeftShoulderChanged += ControllerOnLeftShoulderChanged;
            controller.LeftShoulderPressed += ControllerOnLeftShoulderPressed;
            controller.LeftShoulderReleased += ControllerOnLeftShoulderReleased;
            
            controller.RightShoulderChanged += ControllerOnRightShoulderChanged;
            controller.RightShoulderPressed += ControllerOnRightShoulderPressed;
            controller.RightShoulderReleased += ControllerOnRightShoulderReleased;
            
            controller.LeftTriggerPressureChanged += ControllerOnLeftTriggerPressureChanged;
            controller.RightTriggerPressureChanged += ControllerOnRightTriggerPressureChanged;

            controller.LeftStickPositionChanged += ControllerOnLeftStickPositionChanged;
            controller.RightStickPositionChanged += ControllerOnRightStickPositionChanged;
            
            return controller;
        }

        private static void ControllerOnRightStickButtonPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Right stick pressed");
        }

        private static void ControllerOnLeftStickButtonReleased(object sender, EventArgs e)
        {
            Console.WriteLine("Left stick released");
        }

        private static void ControllerOnBackReleased(object sender, EventArgs e)
        {
            Console.WriteLine("Back released");
        }

        private static void ControllerOnBackPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Back pressed");
        }

        private static void ControllerOnStartReleased(object sender, EventArgs e)
        {
            Console.WriteLine("Start released");
        }

        private static void ControllerOnStartPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Start pressed");
        }

        private static void ControllerOnYReleased(object sender, EventArgs e)
        {
            Console.WriteLine("Y released");
        }

        private static void ControllerOnYPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Y pressed");
        }

        private static void ControllerOnXReleased(object sender, EventArgs e)
        {
            Console.WriteLine("X released");
        }

        private static void ControllerOnXPressed(object sender, EventArgs e)
        {
            Console.WriteLine("X pressed");
        }

        private static void ControllerOnBPressed(object sender, EventArgs e)
        {
            Console.WriteLine("B pressed");
        }

        private static void ControllerOnRightShoulderReleased(object sender, EventArgs e)
        {
            Console.WriteLine("Right shoulder released");
        }

        private static void ControllerOnRightShoulderPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Right shoulder pressed");
        }

        private static void ControllerOnLeftShoulderReleased(object sender, EventArgs e)
        {
            Console.WriteLine("Left shoulder released");
        }

        private static void ControllerOnLeftShoulderPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Left shoulder pressed");
        }

        private static void ControllerOnAPressed(object sender, EventArgs e)
        {
            Console.WriteLine("A pressed");
        }

        private static void ControllerOnAReleased(object sender, EventArgs e)
        {
            Console.WriteLine("A released");
        }

        private static void ControllerOnRightStickPositionChanged(object sender, Point e)
        {
            Console.WriteLine($"Right Stick {e.X} {e.Y}");
        }

        private static void ControllerOnLeftStickPositionChanged(object sender, Point e)
        {
            Console.WriteLine($"Left Stick {e.X} {e.Y}");
        }

        private static void ControllerOnRightTriggerPressureChanged(object sender, byte e)
        {
            Console.WriteLine($"Right Trigger {e}");
        }

        private static void ControllerOnLeftTriggerPressureChanged(object sender, byte e)
        {
            Console.WriteLine($"Left Trigger {e}");
        }

        private static void ControllerOnDigitalStickChanged(object sender, DigitalPad e)
        {
            Console.WriteLine($"Digital pad: {e}");
        }

        private static void ControllerOnRightStickButtonReleased(object sender, EventArgs e)
        {
            Console.WriteLine($"Right stick pressed: {e}");
        }

        private static void ControllerOnLeftStickButtonPressed(object sender, EventArgs e)
        {
            Console.WriteLine($"Left stick pressed: {e}");
        }

        private static void ControllerOnRightShoulderChanged(object sender, bool e)
        {
            Console.WriteLine($"Right shoulder pressed: {e.ToString()}");
        }

        private static void ControllerOnLeftShoulderChanged(object sender, bool e)
        {
            Console.WriteLine($"Left shoulder pressed: {e.ToString()}");
        }

        private static void ControllerOnBackChanged(object sender, bool e)
        {
            Console.WriteLine($"Back pressed: {e.ToString()}");
        }

        private static void ControllerOnStartChanged(object sender, bool e)
        {
            Console.WriteLine($"Start pressed: {e.ToString()}");
        }

        private static void ControllerOnYChanged(object sender, bool e)
        {
            Console.WriteLine($"Y pressed: {e.ToString()}");
        }

        private static void ControllerOnXChanged(object sender, bool e)
        {
            Console.WriteLine($"X pressed: {e.ToString()}");
        }

        private static void ControllerOnBChanged(object sender, bool e)
        {
            Console.WriteLine($"B pressed: {e.ToString()}");
        }

        private static void ControllerOnAChanged(object sender, bool e)
        {
            Console.WriteLine($"A pressed: {e.ToString()}");
        }

        private static void ControllerOnStateChanged(object sender, StateChangedEventArgs e)
        {
            Console.WriteLine(e.CurrentState.ToString());
        }
    }
}
