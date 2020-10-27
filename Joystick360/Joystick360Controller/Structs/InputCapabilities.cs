using System.Runtime.InteropServices;

namespace Joystick360Controller.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct  InputCapabilities
    {
        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(0)]
        private readonly byte Type;

        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(1)]
        private readonly byte SubType;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(2)]
        private readonly short Flags;
        
        [FieldOffset(4)]
        private readonly InputData _data;

        [FieldOffset(16)]
        private readonly InputVibration Vibration;
    }
}