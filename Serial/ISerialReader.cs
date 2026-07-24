using scalecloud_scale_agent.Model;
using System;

namespace scalecloud_scale_agent.Serial
{
    public interface ISerialReader : IDisposable
    {
        bool IsRunning { get; }

        event Action<byte> ByteReceived;

        event Action<Exception> Error;

        void Start(SerialPortSettings settings);

        void Stop();
    }
}