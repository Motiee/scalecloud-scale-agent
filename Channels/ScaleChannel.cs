using scalecloud_scale_agent.Channels.Interfaces;
using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols;
using scalecloud_scale_agent.Protocols.Interfaces;
using scalecloud_scale_agent.Serial;
using System;

namespace scalecloud_scale_agent.Channels
{
    public class ScaleChannel : IScaleChannel
    {
        private readonly object _sync = new object();

        private ScaleSettings _settings = new ScaleSettings();

        private IScaleProtocol _protocol;

        private ISerialReader _reader;

        public int ChannelNumber { get; }

        public ScaleSettings Settings
        {
            get
            {
                lock (_sync)
                {
                    return _settings;
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                lock (_sync)
                {
                    return _reader != null &&
                           _reader.IsRunning;
                }
            }
        }

        public event EventHandler<ScaleData> WeightReceived;

        public event EventHandler<ScaleError> Error;

        public ScaleChannel(int channelNumber)
        {
            ChannelNumber = channelNumber;
        }

        public void ApplySettings(ScaleSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            lock (_sync)
            {
                _settings = settings;

                _protocol = ScaleProtocolRegistry.Create(
                    settings.ProtocolId);
            }
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void Dispose()
        {
            Stop();
        }
    }
}