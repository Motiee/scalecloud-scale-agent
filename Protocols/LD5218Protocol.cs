using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.FrameDetectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Protocols
{
    internal class LD5218Protocol : ScaleProtocolBase
    {
        public override string Id => "LD5218";


        public override string DisplayName => "LD5218";

        public override decimal? PrevWeight { get; set; }

        public LD5218Protocol() : base(new LD5218FrameDetector()) { }
        protected override bool ParseFrame(byte[] frame, out ScaleData data)
        {
            data = null;



            var text_Enc = Encoding.ASCII.GetString(frame).Trim();


            var text = text_Enc.Trim();



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

            return true;
        }

    }
}