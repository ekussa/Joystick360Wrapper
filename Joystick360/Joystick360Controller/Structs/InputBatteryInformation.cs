using System.Runtime.InteropServices;
using Joystick360Controller.Constants;

namespace Joystick360Controller.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct  InputBatteryInformation
    {
        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(0)]
        public byte BatteryType;

        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(1)]
        public byte BatteryLevel;

        public override string ToString()
        {
            return $"{(BatteryTypes) BatteryType} {(BatteryLevel) BatteryLevel}";
        }
    }}