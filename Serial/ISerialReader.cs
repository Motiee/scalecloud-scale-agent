using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Serial
{
    public interface ISerialReader : IDisposable
    {
        event Action<byte> ByteReceived;

        event Action<string> Error;

        bool IsRunning { get; }

        void Start();

        void Stop();
    }
}
