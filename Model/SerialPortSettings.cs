using System.IO.Ports;

namespace scalecloud_scale_agent.Model
{
    public class SerialPortSettings
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; } = 9600;

        public Parity Parity { get; set; } = Parity.None;

        public int DataBits { get; set; } = 8;

        public StopBits StopBits { get; set; } = StopBits.One;

        public bool DtrEnable { get; set; }

        public bool RtsEnable { get; set; }

        public int ReadTimeout { get; set; } = 500;
    }
}