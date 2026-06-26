using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Text;

public class Toledo8142Protocol : ScaleProtocolBase
{
    public override string Id => "Toledo8142";

    public override string DisplayName => "Toledo 8142";

    public Toledo8142Protocol():base (new CarriageReturnFrameDetector()) {}
    protected override bool ParseFrame(byte[] frame, out ScaleData data)
    {
        data = null;

        var text = Encoding.ASCII.GetString(frame);

        text = text.Trim();

        if (!decimal.TryParse(
            text,
            out decimal weight))
        {
            return false;
        }

        data = new ScaleData
        {
            Weight = weight,
            Stable = true,
            Time = DateTime.Now
        };

        return true;
    }

}