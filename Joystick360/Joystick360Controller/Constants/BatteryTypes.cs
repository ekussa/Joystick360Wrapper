namespace Joystick360Controller.Constants
{
    /// <summary>
    /// Flags for battery status level
    /// </summary>
    public enum BatteryTypes : byte
    {
        /// <summary>
        /// This device is not connected
        /// </summary>
        Disconnected = 0x00,
        
        /// <summary>
        /// Wired device, no battery
        /// </summary>
        Wired = 0x01,
        
        /// <summary>
        /// Alkaline battery source
        /// </summary>
        Alkaline =0x02,
        
        /// <summary>
        /// Nickel Metal Hydride battery source
        /// </summary>
        Nimh = 0x03,
        
        /// <summary>
        /// Cannot determine the battery type
        /// </summary>
        Unknown = 0xFF,
    }
}
