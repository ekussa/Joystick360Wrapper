
namespace Joystick360Controller
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override bool Equals(object obj)
        {
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public bool Equals(Point obj)
        {
            return obj.X == X && obj.Y == Y;
        }
    }
}
