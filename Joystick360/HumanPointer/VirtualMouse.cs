using System.Runtime.InteropServices;

namespace HumanPointer
{
    public class VirtualMouse : IPointerMover
    {
        private const int MoveParameter = 0x0001;
        private const int LeftDown = 0x0002;
        private const int LeftUp = 0x0004;
        private const int RightDown = 0x0008;
        private const int RightUp = 0x0010;
        private const int MiddleDown = 0x0020;
        private const int MiddleUp = 0x0040;
        private const int AbsoluteParameter = 0x8000;
        private const int Wheel = 0x0800;

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out ApiPoint point);
        
        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct ApiPoint
        {
            public readonly int X;
            public readonly int Y;
        }

        public void LeftClickDown()
        {
            InternalLeftClickDown();
        }

        public void LeftClickUp()
        {
            InternalLeftClickUp();
        }

        public void RightClickDown()
        {
            InternalRightClickDown();
        }

        public void RightClickUp()
        {
            InternalRightClickUp();
        }

        public void Move(int x, int y)
        {
            InternalMove(x, y);
        }

        private static void InternalMove(int xDelta, int yDelta)
        {
            mouse_event(MoveParameter, xDelta, yDelta, 0, 0);
        }
        
        private static void InternalLeftClickDown()
        {
            GetCursorPos(out var point);
            mouse_event(LeftDown, point.X, point.Y, 0, 0);
        }
        
        private static void InternalLeftClickUp()
        {
            GetCursorPos(out var point);
            mouse_event(LeftUp, point.X, point.Y, 0, 0);
        }
        
        private static void InternalRightClickDown()
        {
            GetCursorPos(out var point);
            mouse_event(RightDown, point.X, point.Y, 0, 0);
        }
        
        private static void InternalRightClickUp()
        {
            GetCursorPos(out var point);
            mouse_event(RightUp, point.X, point.Y, 0, 0);
        }
    }
}
