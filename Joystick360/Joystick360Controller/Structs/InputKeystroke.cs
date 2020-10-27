using System.Runtime.InteropServices;

namespace Joystick360Controller.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct  InputKeystroke
    {
        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(0)]
        private readonly short VirtualKey;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(2)]
        private readonly char Unicode;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(4)]
        private readonly short Flags;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(5)]
        private readonly byte UserIndex;

        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(6)]
        private readonly byte HidCode;
    }
}