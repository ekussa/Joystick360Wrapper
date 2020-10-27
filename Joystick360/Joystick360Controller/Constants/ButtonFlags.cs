namespace Joystick360Controller.Constants
{
    public enum ButtonFlags : ushort
    {
        DigitalPadUp = 0x0001,
        DigitalPadDown = 0x0002,
        DigitalPadLeft = 0x0004,
        DigitalPadRight = 0x0008,
        Start = 0x0010,
        Back = 0x0020,
        LeftThumb = 0x0040,
        RightThumb = 0x0080,
        LeftShoulder = 0x0100,
        RightShoulder = 0x0200,
        A = 0x1000,
        B = 0x2000,
        X = 0x4000,
        Y = 0x8000,
        Zero = 0,
    }
}
