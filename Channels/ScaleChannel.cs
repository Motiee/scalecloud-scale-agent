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
        private readonly object _sync =
            new object();

        private ScaleSettings _settings =
            new ScaleSettings();

        private IScaleProtocol _protocol;

        private ISerialReader _reader;

        public int ChannelNumber { get; }

        public ScaleSettings Settings => _settings;

        public bool IsRunning =>
            _reader != null &&
            _reader.IsRunning;

        public event EventHandler<ScaleData> WeightReceived;

        public event EventHandler<ScaleError>Error;

        public ScaleChannel(int channelNumber)
        {
            ChannelNumber =channelNumber;
        }

        public void ApplySettings(ScaleSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(
                    nameof(settings));

            lock (_sync)
            {
                bool restart = IsRunning;

                if (restart)
                {
                    Stop();
                }

                _settings = settings;

                _protocol =
                    ScaleProtocolRegistry.Create(
                        settings.Protocol.ProtocolId);

                if (restart)
                {
                    Start();
                }
            }
        }

        public void Start()
        {
            lock (_sync)
            {
                if (_settings == null)
                    return;

                if (!_settings.Enabled)
                    return;

                if (_protocol == null)
                    return;

                if (_reader != null)
                    return;

                _reader =new SerialReader();
                try
                {
                    _reader.ByteReceived += Reader_ByteReceived;

                    _reader.Error += Reader_Error;

                    _reader.Start(_settings.SerialPort);
                }
                catch (Exception)
                {

                    _reader.Dispose();
                    _reader = null;
                    throw;
                }


            }
        }

        public void Stop()
        {
            lock (_sync)
            {
                if (_reader == null)
                    return;

                _reader.ByteReceived -=
                    Reader_ByteReceived;

                _reader.Error -=
                    Reader_Error;

                _reader.Dispose();

                _reader = null;

                _protocol?.Reset();
            }
        }

        private void Reader_ByteReceived(byte value)
        {
            if (_protocol == null)
                return;

            ScaleData data;

             if (_protocol.Push(value,out data))
             {
                WeightReceived?.Invoke(this,data);
            }
        }

        private void Reader_Error(Exception ex)
        {
            Error?.Invoke(
                this,
                new ScaleError
                {
                    Time = DateTime.Now,
                    Message = ex.Message,
                    Exception = ex
                });
        }

        public void Dispose()
        {
            Stop();
        }
    }
}