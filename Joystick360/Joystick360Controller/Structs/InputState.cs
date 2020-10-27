using System.Runtime.InteropServices;

namespace Joystick360Controller.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct InputState
    {
        [FieldOffset(0)]
        public int PacketNumber;

        [FieldOffset(4)]
        public InputData Data;

        public void Copy(InputState source)
        {
            PacketNumber = source.PacketNumber;
            Data.Copy(source.Data);
        }

        public override bool Equals(object obj)
        {
            return obj is InputState state && Equals(state);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (PacketNumber * 397) ^ Data.GetHashCode();
            }
        }

        public bool Equals(InputState other)
        {
            return PacketNumber == other.PacketNumber
                   && Data.Equals(other.Data);
        }
    }
}
