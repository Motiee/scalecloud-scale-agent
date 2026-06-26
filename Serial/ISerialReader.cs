using System;

namespace scalecloud_scale_agent.Serial
{
    public interface ISerialReader : IDisposable
    {
        bool IsRunning { get; }

        event Action<byte> ByteReceived;

        event Action<Exception> Error;

        void Start(
            string portName,
            int baudRate,
            System.IO.Ports.Parity parity,
            int dataBits,
            System.IO.Ports.StopBits stopBits);

        void Stop();
    }
}