using Newtonsoft.Json;
using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Settings.Interfaces;
using System;
using System.IO;

namespace scalecloud_scale_agent.Settings
{
    public class JsonSettingsRepository
        : ISettingsRepository
    {
        public AgentSettings Load()
        {
            if (!File.Exists(
                SettingsPaths.SettingsFile))
            {
                return CreateDefault();
            }

            string json =File.ReadAllText(SettingsPaths.SettingsFile);

            var settings =JsonConvert.DeserializeObject<AgentSettings>(json);

            return settings ?? CreateDefault();
        }

        public void Save(AgentSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            string json =
                JsonConvert.SerializeObject(
                    settings,
                    Formatting.Indented);

            string tempFile =
                SettingsPaths.SettingsFile + ".tmp";

            File.WriteAllText(
                tempFile,
                json);

            if (File.Exists(SettingsPaths.SettingsFile))
            {
                File.Delete(SettingsPaths.SettingsFile);
            }

            File.Move(
                tempFile,
                SettingsPaths.SettingsFile);
        }

        private AgentSettings CreateDefault()
        {
            return new AgentSettings();
        }
    }
}