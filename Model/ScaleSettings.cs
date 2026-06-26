using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Model
{
    public class ScaleSettings
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public Parity Parity { get; set; }

        public StopBits StopBits { get; set; }

        public string ProtocolId { get; set; }

        public bool Enabled { get; set; } = true;
        public int ReadTimeout { get; set; } = 500;
    }
}
