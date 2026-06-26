using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.State
{
    public class WebSocketState
    {
        public bool Running { get; set; }

        public int ClientCount { get; set; }

        public int Port { get; set; }
    }
}
