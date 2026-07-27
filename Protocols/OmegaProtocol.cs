using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.FrameDetectors;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Protocols
{
    public class OmegaProtocol : ScaleProtocolBase
    {
        public override string Id => "Omega";


        public override string DisplayName => "Omega";

        public override decimal? PrevWeight { get; set; }

        public OmegaProtocol() : base(new FrameDetector(new byte[] { 13 })) { }
        protected override bool ParseFrame(byte[] frame, out ScaleData data)
        {
            data = null;

            if (frame.Length < 7) return false;

            var text = Encoding.ASCII.GetString(frame).Trim();
            text = text.Substring(0, text.Length - 1).Replace(" ","");

            if (!decimal.TryParse(
                text,
                out decimal weight))
            {
                return false;
            }

            data = new ScaleData
            {
                Weight = weight,
                Stable = (weight == PrevWeight),
                Time = DateTime.Now
            };

            PrevWeight = data.Weight;
            Console.WriteLine(data.Weight);
            return true;
        }

    }
}
