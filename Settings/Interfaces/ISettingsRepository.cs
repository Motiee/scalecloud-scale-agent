using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Settings;

namespace scalecloud_scale_agent.Settings.Interfaces
{
    public interface ISettingsRepository
    {
        AgentSettings Load();

        void Save(AgentSettings settings);
    }
}