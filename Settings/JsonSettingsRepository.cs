using Newtonsoft.Json;
using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Settings.Interfaces;
using System;
using System.IO;
using System.Text;

namespace scalecloud_scale_agent.Settings
{
    public class JsonSettingsRepository : ISettingsRepository
    {
        public AgentSettings Load()
        {
            if (!File.Exists(SettingsPaths.SettingsFile))
            {
                AgentSettings settings = CreateDefault();

                Save(settings);

                return settings;
            }

            try
            {
                string json =
                    File.ReadAllText(
                        SettingsPaths.SettingsFile,
                        Encoding.UTF8);

                AgentSettings settings =
                    JsonConvert.DeserializeObject<AgentSettings>(json);

                if (settings == null)
                {
                    settings = CreateDefault();

                    Save(settings);
                }

                return settings;
            }
            catch
            {
                BackupBrokenSettings();

                AgentSettings settings =
                    CreateDefault();

                Save(settings);

                return settings;
            }
        }

        public void Save(AgentSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            string directory =
                Path.GetDirectoryName(SettingsPaths.SettingsFile);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json =
                JsonConvert.SerializeObject(
                    settings,
                    Formatting.Indented);

            string tempFile =
                SettingsPaths.SettingsFile + ".tmp";

            File.WriteAllText(
                tempFile,
                json,
                Encoding.UTF8);

            if (File.Exists(SettingsPaths.SettingsFile))
            {
                File.Delete(SettingsPaths.SettingsFile);
            }

            File.Move(
                tempFile,
                SettingsPaths.SettingsFile);
        }

        private void BackupBrokenSettings()
        {
            try
            {
                if (!File.Exists(SettingsPaths.SettingsFile))
                    return;

                string backupFile =
                    SettingsPaths.SettingsFile + ".bad";

                if (File.Exists(backupFile))
                {
                    File.Delete(backupFile);
                }

                File.Move(
                    SettingsPaths.SettingsFile,
                    backupFile);
            }
            catch
            {
                // intentionally ignored
            }
        }

        private AgentSettings CreateDefault()
        {
            return new AgentSettings
            {
                WebSocketPort = 47895,

                StartWithWindows = false,

                MinimizeToTray = true,

                Channel1 = new ScaleSettings
                {
                    ChannelId = ScaleChannelId.Bascule1,

                    Enabled = true,

                    SerialPort =
                    {
                        PortName = "COM1"
                    },

                    Protocol =
                    {
                        ProtocolId = "Toledo8142"
                    }
                },

                Channel2 = new ScaleSettings
                {
                    ChannelId = ScaleChannelId.Bascule2,

                    Enabled = true,

                    SerialPort =
                    {
                        PortName = "COM2"
                    },

                    Protocol =
                    {
                        ProtocolId = "Toledo8142"
                    }
                }
            };
        }
    }
}