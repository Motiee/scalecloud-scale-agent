using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.State
{
    public class ApplicationState
    {
        public ScaleState Scale { get; }= new ScaleState();

        public WebSocketState WebSocket { get; }= new WebSocketState();

        public TrayState Tray { get; }= new TrayState();
    }
}
