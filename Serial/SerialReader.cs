using scalecloud_scale_agent.Model;
using System;

namespace scalecloud_scale_agent.Serial
{
    public class SerialReader : ISerialReader
    {
        public event Action<byte> ByteReceived;

        public event Action<string> Error;

        public bool IsRunning => false;

        public SerialReader(ScaleSettings settings)
        {

        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void Dispose()
        {
            Stop();
        }
    }
}