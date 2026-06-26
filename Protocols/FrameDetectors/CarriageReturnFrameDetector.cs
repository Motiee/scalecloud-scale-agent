using scalecloud_scale_agent.Protocols.Interfaces;
using System.Collections.Generic;

public class CarriageReturnFrameDetector: IFrameDetector
{
    private readonly List<byte> _buffer = new List<byte>();

    public bool Push(byte value,out byte[] frame)
    {
        frame = null;

        if (value == 13)
        {
            if (_buffer.Count == 0)
            {
                frame = null;
                return false;
            }

            frame = _buffer.ToArray();

            _buffer.Clear();

            return true;
        }

        _buffer.Add(value);

        return false;
    }

    public void Reset()
    {
        _buffer.Clear();
    }
}