using scalecloud_scale_agent.Model;
using System;

namespace scalecloud_scale_agent.Channels.Interfaces
{
    public interface IScaleChannel : IDisposable
    {
        int ChannelNumber { get; }

        ScaleSettings Settings { get; }

        event EventHandler<ScaleData> WeightReceived;

        event EventHandler<ScaleError> Error;

        void ApplySettings(ScaleSettings settings);

        void Start();

        void Stop();
    }
}