using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols.Interfaces;

public abstract class ScaleProtocolBase: IScaleProtocol
{
    private readonly IFrameDetector _frameDetector;

    protected ScaleProtocolBase(IFrameDetector frameDetector)
    {
        _frameDetector = frameDetector;
    }

    public abstract string Id { get; }

    public abstract string DisplayName { get; }

    public bool Push(byte value, out ScaleData data)
    {
        data = null;

        byte[] frame;

        if (!_frameDetector.Push(value, out frame))
            return false;

        return ParseFrame(frame, out data);
    }

    public virtual void Reset()
    {
        _frameDetector.Reset();
    }

    protected abstract bool ParseFrame(byte[] frame,out ScaleData data);
}