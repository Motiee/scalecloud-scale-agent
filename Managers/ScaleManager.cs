using scalecloud_scale_agent.Channels;
using scalecloud_scale_agent.Channels.Interfaces;
using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scalecloud_scale_agent.Managers
{
    public class ScaleManager : IScaleManager
    {
        private readonly List<IScaleChannel> _channels;

        private readonly ISettingsRepository _settingsRepository;

        private AgentSettings _agentSettings;

        public IReadOnlyList<IScaleChannel> Channels => _channels;

        public int ChannelCount => _channels.Count;

        public ScaleManager(
            ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;

            _channels = new List<IScaleChannel>
            {
                new ScaleChannel((int)ScaleChannelId.Bascule1),
                new ScaleChannel((int)ScaleChannelId.Bascule2)
            };
        }

        public void LoadSettings()
        {
            _agentSettings =
                _settingsRepository.Load();

            GetChannel(ScaleChannelId.Bascule1)
                .ApplySettings(_agentSettings.Channel1);

            GetChannel(ScaleChannelId.Bascule2)
                .ApplySettings(_agentSettings.Channel2);
        }

        public void SaveSettings()
        {
            if (_agentSettings == null)
            {
                _agentSettings = new AgentSettings();
            }

            _agentSettings.Channel1 =
                GetChannel(
                    ScaleChannelId.Bascule1)
                .Settings;

            _agentSettings.Channel2 =
                GetChannel(
                    ScaleChannelId.Bascule2)
                .Settings;

            _settingsRepository.Save(
                _agentSettings);
        }

        public void Start()
        {
            foreach (var channel in _channels)
            {
                channel.Start();
            }
        }

        public void Stop()
        {
            foreach (var channel in _channels)
            {
                channel.Stop();
            }
        }

        public IScaleChannel GetChannel(
            ScaleChannelId channelId)
        {
            return _channels.FirstOrDefault(
                c => c.ChannelNumber ==
                (int)channelId);
        }

        public void Dispose()
        {
            Stop();

            foreach (var channel in _channels)
            {
                channel.Dispose();
            }
        }
    }
}