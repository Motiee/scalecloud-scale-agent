using scalecloud_scale_agent.Channels.Interfaces;
using scalecloud_scale_agent.Model;
using System;
using System.Collections.Generic;

namespace scalecloud_scale_agent.Managers
{
    public interface IScaleManager : IDisposable
    {
        IReadOnlyList<IScaleChannel> Channels { get; }

        void Start();

        void Stop();

        void LoadSettings();

        void SaveSettings();

        IScaleChannel GetChannel(ScaleChannelId channelId);
    }
}