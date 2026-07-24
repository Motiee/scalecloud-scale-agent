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
    public class YaohuaProtocol : ScaleProtocolBase
    {
        public override string Id => "Yaohua";


        public override string DisplayName => "Yaohua";

        public override decimal? PrevWeight { get; set; }

        public YaohuaProtocol() : base(new FrameDetector(new byte[] { 61 })) { }
        protected override bool ParseFrame(byte[] frame, out ScaleData data)
        {
            data = null;
        
            var text_Enc = Encoding.ASCII.GetString(frame).Trim();
            var text = "";
            for (int i = text_Enc.Length - 1; i >= 0; i--)
            {
                text = text+text_Enc[i];
            }


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
