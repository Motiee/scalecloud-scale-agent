using scalecloud_scale_agent.Model;
using System.Collections.Generic;

namespace scalecloud_scale_agent.Model
{
    public class AgentSettings
    {
        /// <summary>
        /// WebSocket server port.
        /// </summary>
        public int WebSocketPort { get; set; } = 47895;

        /// <summary>
        /// Start Agent when Windows starts.
        /// </summary>
        public bool StartWithWindows { get; set; }

        /// <summary>
        /// Minimize to system tray.
        /// </summary>
        public bool MinimizeToTray { get; set; } = true;

        /// <summary>
        /// All configured scale channels.
        /// </summary>
        public ScaleSettings Channel1 { get; set; } = new ScaleSettings();
        public ScaleSettings Channel2 { get; set; } = new ScaleSettings();
    }
}