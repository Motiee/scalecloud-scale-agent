using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Model
{
    // TODO (2026-06):
    // Version 2:
    // Make this class immutable.
    // Settings should only be changed through ScaleChannel.ApplySettings()
    // Convert ScaleSettings to immutable after SettingsRepository is implemented.
    // Current mutable version keeps development simple while architecture is evolving.

    public class ScaleSettings
    {
        public ScaleSettings()
        {
            ChannelId = ScaleChannelId.Unknown;
        }
        public ScaleChannelId ChannelId { get; set; }

        public bool Enabled { get; set; } = true;

        public SerialPortSettings SerialPort { get; set; }= new SerialPortSettings();

        public ProtocolSettings Protocol { get; set; }= new ProtocolSettings();
    }
}
