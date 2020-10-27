using System.Text;

namespace Joystick360Controller
{
    public class DigitalPad
    {
        private readonly bool _up;
        private readonly bool _down;
        private readonly bool _right;
        private readonly bool _left;
        
        public bool Up => _up;
        public bool Down => _down;
        public bool Right => _right;
        public bool Left => _left;

        public DigitalPad(bool up, bool down, bool left, bool right)
        {
            _up = up;
            _down = down;
            _right = right;
            _left = left;
        }

        public override bool Equals(object obj)
        {
            return Equals((DigitalPad)obj);
        }

        public bool Equals(DigitalPad other)
        {
            return _up == other._up && _down == other._down && _right == other._right && _left == other._left;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _up.GetHashCode();
                hashCode = (hashCode * 397) ^ _down.GetHashCode();
                hashCode = (hashCode * 397) ^ _right.GetHashCode();
                hashCode = (hashCode * 397) ^ _left.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(_up ? "Up " : "");
            sb.Append(_down ? "Down " : "");
            sb.Append(_left ? "Left " : "");
            sb.Append(_right ? "Right " : "");
            return sb.ToString().TrimEnd();
        }
    }
}
