using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.FrameDetectors;
using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Text;

public class AlphaProtocol : ScaleProtocolBase
{
    public override string Id => "Alpha";


    public override string DisplayName => "Alpha";

    public override decimal? PrevWeight { get; set; }

    public AlphaProtocol() : base(new CarriageReturnFrameDetector()) { }
    protected override bool ParseFrame(byte[] frame, out ScaleData data)
    {
        data = null;

        if (frame.Length < 7) return false;

        var text_Enc = Encoding.ASCII.GetString(frame).Trim();


        var text = text_Enc.Trim().Substring(0, text_Enc.Length );

   

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