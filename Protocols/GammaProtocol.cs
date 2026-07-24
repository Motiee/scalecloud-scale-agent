using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.FrameDetectors;
using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Text;

public class GammaProtocol : ScaleProtocolBase
{
    public override string Id => "Gamma";

    
    public override string DisplayName => "Gamma";

    public override decimal? PrevWeight { get ; set; }

    public GammaProtocol() : base(new CarriageReturnFrameDetector()) { }
    protected override bool ParseFrame(byte[] frame, out ScaleData data)
    {
        data = null;
        
        if (frame.Length < 7) return false;
        
        var text_Enc = Encoding.ASCII.GetString(frame).Trim();
        

        var text = text_Enc.Trim().Substring(0, text_Enc.Length-1);

        var unit = text_Enc.Trim().Substring(text_Enc.Length-1,1);

        if (!decimal.TryParse(
            text,
            out decimal weight))
        {
            return false;
        }

        data = new ScaleData
        {
            Weight = weight,
            Stable = (weight==PrevWeight),
            Unit=unit,
            Time = DateTime.Now
        };

        PrevWeight = data.Weight;
        return true;
    }

}