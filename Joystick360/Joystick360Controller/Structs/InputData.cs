using System.Runtime.InteropServices;
using System.Text;
using Joystick360Controller.Constants;

namespace Joystick360Controller.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct InputData
    {
        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(0)]
        public ushort wButtons;

        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(2)]
        public byte bLeftTrigger;

        [MarshalAs(UnmanagedType.I1)]
        [FieldOffset(3)]
        public byte bRightTrigger;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(4)]
        public short sThumbLX;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(6)]
        public short sThumbLY;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(8)]
        public short sThumbRX;

        [MarshalAs(UnmanagedType.I2)]
        [FieldOffset(10)]
        public short sThumbRY;

        private bool ButtonPressed(ushort buttonFlags)
        {
            return (wButtons & buttonFlags) == buttonFlags;
        }

        public void Copy(InputData source)
        {
            sThumbLX = source.sThumbLX;
            sThumbLY = source.sThumbLY;
            sThumbRX = source.sThumbRX;
            sThumbRY = source.sThumbRY;
            bLeftTrigger = source.bLeftTrigger;
            bRightTrigger = source.bRightTrigger;
            wButtons = source.wButtons;
        }

        public override bool Equals(object obj)
        {
            return obj is InputData gamepad && Equals(gamepad);
        }

        public bool Equals(InputData other)
        {
            return wButtons == other.wButtons
                   && bLeftTrigger == other.bLeftTrigger
                   && bRightTrigger == other.bRightTrigger
                   && sThumbLX == other.sThumbLX
                   && sThumbLY == other.sThumbLY
                   && sThumbRX == other.sThumbRX
                   && sThumbRY == other.sThumbRY;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = wButtons.GetHashCode();
                hashCode = (hashCode * 397) ^ bLeftTrigger.GetHashCode();
                hashCode = (hashCode * 397) ^ bRightTrigger.GetHashCode();
                hashCode = (hashCode * 397) ^ sThumbLX.GetHashCode();
                hashCode = (hashCode * 397) ^ sThumbLY.GetHashCode();
                hashCode = (hashCode * 397) ^ sThumbRX.GetHashCode();
                hashCode = (hashCode * 397) ^ sThumbRY.GetHashCode();
                return hashCode;
            }
        }

        public string ToRawString()
        {
            return $"{wButtons} {bLeftTrigger} {bRightTrigger} {sThumbLX} {sThumbLY} {sThumbRX} {sThumbRY} ";
        }

        public override string ToString()
        {
            var none = string.Empty;
            var sb = new StringBuilder();
            sb.Append(IsAPressed ? "A " : none);
            sb.Append(IsBPressed ? "B " : none);
            sb.Append(IsXPressed ? "X " : none);
            sb.Append(IsYPressed ? "Y " : none);
            sb.Append(IsLeftShoulderPressed ? "LB " : none);
            sb.Append(IsRightShoulderPressed ? "RB " : none);
            sb.Append(IsLeftStickPressed ? "LeftStick " : none);
            sb.Append(IsRightStickPressed ? "RightStick " : none);
            sb.Append(IsStartPressed ? "Start " : none);
            sb.Append(IsBackPressed ? "Back " : none);
            sb.Append(IsDPadDownPressed ? "Down " : none);
            sb.Append(IsDPadUpPressed ? "Up " : none);
            sb.Append(IsDPadLeftPressed ? "Left " : none);
            sb.Append(IsDPadRightPressed ? "Right " : none);

            sb.Append($"LSck X:{LeftThumbStickPosition.X} Y:{LeftThumbStickPosition.Y} ");
            sb.Append($"RSck X:{RightThumbStickPosition.X} Y:{RightThumbStickPosition.Y} ");
            
            sb.Append($"LTrg {LeftTriggerPressure} ");
            sb.Append($"RTrg {RightTriggerPressure} ");
            
            return sb.ToString();
        }

        #region Digital Button States
        public bool IsDPadUpPressed => ButtonPressed((ushort)ButtonFlags.DigitalPadUp);

        public bool IsDPadDownPressed => ButtonPressed((ushort)ButtonFlags.DigitalPadDown);

        public bool IsDPadLeftPressed => ButtonPressed((ushort)ButtonFlags.DigitalPadLeft);

        public bool IsDPadRightPressed => ButtonPressed((ushort)ButtonFlags.DigitalPadRight);

        public bool IsAPressed => ButtonPressed((ushort)ButtonFlags.A);

        public bool IsBPressed => ButtonPressed((ushort)ButtonFlags.B);

        public bool IsXPressed => ButtonPressed((ushort)ButtonFlags.X);

        public bool IsYPressed => ButtonPressed((ushort)ButtonFlags.Y);

        public bool IsBackPressed => ButtonPressed((ushort)ButtonFlags.Back);

        public bool IsStartPressed => ButtonPressed((ushort)ButtonFlags.Start);

        public bool IsLeftShoulderPressed => ButtonPressed((ushort)ButtonFlags.LeftShoulder);

        public bool IsRightShoulderPressed => ButtonPressed((ushort)ButtonFlags.RightShoulder);

        public bool IsLeftStickPressed => ButtonPressed((ushort)ButtonFlags.LeftThumb);

        public bool IsRightStickPressed => ButtonPressed((ushort)ButtonFlags.RightThumb);
        #endregion

        public DigitalPad GetDigitalPad =>
            new DigitalPad(IsDPadUpPressed, IsDPadDownPressed, IsDPadLeftPressed, IsDPadRightPressed);
        
        #region Analogue Input States
        public byte LeftTriggerPressure => bLeftTrigger;

        public byte RightTriggerPressure => bRightTrigger;

        public Point LeftThumbStickPosition =>
            new Point
            (
                sThumbLX,
                sThumbLY
            );

        public Point RightThumbStickPosition =>
            new Point
            (
                sThumbRX,
                sThumbRY
            );
        #endregion
    }
}
