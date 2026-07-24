using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Protocols.Interfaces
{
    public interface IFrameDetector
    {
        bool Push(byte value,out byte[] frame);
        void Reset();
    }
}
