using System;

public class ByteReceivedEventArgs
    : EventArgs
{
    public byte Value { get; }

    public ByteReceivedEventArgs(byte value)
    {
        Value = value;
    }
}