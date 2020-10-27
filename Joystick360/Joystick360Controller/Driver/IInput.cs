using Joystick360Controller.Structs;

namespace Joystick360Controller.Driver
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwUserIndex">[in] Index of the gamer associated with the device</param>
        /// <param name="state">[out] Receives the current state</param>
        /// <returns></returns>
        int GetState(int dwUserIndex, ref InputState state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwUserIndex">[in] Index of the gamer associated with the device</param>
        /// <param name="vibration">[in, out] The vibration information to send to the controller</param>
        /// <returns></returns>
        int SetState(int dwUserIndex, ref InputVibration vibration);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwUserIndex">[in] Index of the gamer associated with the device</param>
        /// <param name="dwFlags">[in] Input flags that identify the device type</param>
        /// <param name="pCapabilities">[out] Receives the capabilities</param>
        /// <returns></returns>
        int GetCapabilities(int dwUserIndex, int dwFlags, ref InputCapabilities pCapabilities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwUserIndex">Index of the gamer associated with the device</param>
        /// <param name="devType">Which device on this user index</param>
        /// <param name="batteryInformation">Contains the level and types of batteries</param>
        /// <returns></returns>
        int GetBatteryInformation(int dwUserIndex, byte devType, ref InputBatteryInformation batteryInformation);
    }
}
