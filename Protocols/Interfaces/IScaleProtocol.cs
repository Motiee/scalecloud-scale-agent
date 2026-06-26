using scalecloud_scale_agent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Protocols.Interfaces
{
    public interface IScaleProtocol
    {
        string Id { get; }

        string DisplayName { get; }

        bool Push(byte value, out ScaleData data);

        void Reset();
    }
}
