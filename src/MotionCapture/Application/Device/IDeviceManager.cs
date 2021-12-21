﻿namespace MotionCapture.Application.Device
{
    public interface IDeviceManager
    {
        Task WaitForInitialize();

        void DisableLed(LedColor color);

        void EnableLed(LedColor color);

        void ToggleLed(LedColor color, bool enable);

        void RegisterForButtonPressCallback(Func<CancellationToken, Task> onButtonPress);  // TODO: ValueTask?

        void RegisterForMontionSensorCallback(Func<CancellationToken, Task> onMotionStarted, Func<CancellationToken, Task> onMotionStopped);

        void Reset();
    }
}
