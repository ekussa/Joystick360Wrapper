using System.Runtime.InteropServices;
using Joystick360Controller.Structs;

namespace Joystick360Controller.Driver
{
    public class Input : IInput
    {
        public int GetState(int dwUserIndex, ref InputState state)
        {
            return internalXInputGetState(dwUserIndex, ref state);
        }

        public int SetState(int dwUserIndex, ref InputVibration vibration)
        {
            return internalXInputSetState(dwUserIndex, ref vibration);
        }

        public int GetCapabilities(int dwUserIndex, int dwFlags, ref InputCapabilities pCapabilities)
        {
            return internalXInputGetCapabilities(dwUserIndex, dwFlags, ref pCapabilities);
        }

        public int GetBatteryInformation(int dwUserIndex, byte devType, ref InputBatteryInformation batteryInformation)
        {
            return internalXInputGetBatteryInformation(dwUserIndex, devType, ref batteryInformation);
        }

        private const string XInputBinaryName = "xinput1_4.dll";
        
        [DllImport(XInputBinaryName, EntryPoint = "XInputGetState")]
        private static extern int internalXInputGetState
        (
            int dwUserIndex,
            ref InputState pState
        );

        [DllImport(XInputBinaryName, EntryPoint = "XInputSetState")]
        private static extern int internalXInputSetState
        (
            int dwUserIndex,
            ref InputVibration pVibration
        );

        [DllImport(XInputBinaryName, EntryPoint = "XInputGetCapabilities")]
        private static extern int internalXInputGetCapabilities
        (
            int dwUserIndex,
            int dwFlags,
            ref InputCapabilities pCapabilities
        );


        [DllImport(XInputBinaryName, EntryPoint = "XInputGetBatteryInformation")]
        private static extern int internalXInputGetBatteryInformation
        (
            int dwUserIndex,
            byte devType,
            ref InputBatteryInformation pBatteryInformation
        );
    }
}
