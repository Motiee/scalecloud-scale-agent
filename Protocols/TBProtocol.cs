using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.FrameDetectors;
using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Text;

public class TBProtocol : ScaleProtocolBase
{
    public override string Id => "TB";


    public override string DisplayName => "TB";

    public override decimal? PrevWeight { get; set; }

    public TBProtocol() : base(new CommaFrameDetector()) { }
    protected override bool ParseFrame(byte[] frame, out ScaleData data)
    {
        data = null;



        var text_Enc = Encoding.ASCII.GetString(frame).Trim();


        var text = text_Enc.Trim().Substring(0, 5);



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