using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Model
{
    public class ScaleError
    {
        public DateTime Time { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }


    }
}
