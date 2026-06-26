using System;

public abstract class ScaleEvent
{
    public DateTime Time { get; }

    protected ScaleEvent()
    {
        Time = DateTime.UtcNow;
    }
}