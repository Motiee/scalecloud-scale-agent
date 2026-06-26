using scalecloud_scale_agent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.State
{
    public class ScaleChannelState
    {
        public ScaleChannelId ChannelId { get; set; }

        public decimal? Weight { get; set; }

        public bool Stable { get; set; }

        public bool Connected { get; set; }

        public DateTime? LastReceiveTime { get; set; }

        public string ErrorMessage { get; set; }
    }
}
