using System.Runtime.InteropServices;

namespace Joystick360Controller.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct  InputVibration
    {
        [MarshalAs(UnmanagedType.I2)]
        public ushort LeftMotorSpeed;

        [MarshalAs(UnmanagedType.I2)]
        public ushort RightMotorSpeed;
    }
}
