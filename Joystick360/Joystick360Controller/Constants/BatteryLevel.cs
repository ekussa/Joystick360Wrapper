﻿namespace Joystick360Controller.Constants
{
    /// <summary>
    /// These are only valid for wireless, connected devices, with known battery types
    /// The amount of use time remaining depends on the type of device.
    /// </summary>
    public enum BatteryLevel
    {
        Empty = 0x00,
        Low = 0x01,
        Medium = 0x02,
        Full = 0x03,
    }
}
