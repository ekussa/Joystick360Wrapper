using System;
using HumanPointer;
using Joystick360Controller;

namespace Application
{
    public class MouseControllableFromBothSticks : ICreatableEvents
    {
        private readonly VirtualMouse _mouse;

        public MouseControllableFromBothSticks()
        {
            _mouse = new VirtualMouse();
        }
        
        public IControllerEvents DumpEvents()
        {
            var controller = new ConcreteControllerEvents();

            controller.LeftShoulderPressed += ControllerOnLeftShoulderPressed;
            controller.LeftShoulderReleased += ControllerOnLeftShoulderReleased;
            
            controller.RightStickButtonPressed += ControllerOnRightStickButtonPressed;
            controller.RightShoulderReleased += ControllerOnRightShoulderReleased;
            
            controller.LeftStickPositionChanged += ControllerOnStickPositionChanged;
            controller.RightStickPositionChanged += ControllerOnStickPositionChanged;

            return controller;
        }

        private void ControllerOnRightShoulderReleased(object sender, EventArgs e)
        {
            _mouse.RightClickUp();
        }

        private void ControllerOnRightStickButtonPressed(object sender, EventArgs e)
        {
            _mouse.RightClickDown();
        }

        private void ControllerOnLeftShoulderReleased(object sender, EventArgs e)
        {
            _mouse.LeftClickUp();
        }

        private void ControllerOnLeftShoulderPressed(object sender, EventArgs e)
        {
            _mouse.LeftClickDown();
        }

        private void ControllerOnStickPositionChanged(object sender, Point e)
        {
            _mouse.Move(e.X/1000, -e.Y/1000);
        }
    }
}
