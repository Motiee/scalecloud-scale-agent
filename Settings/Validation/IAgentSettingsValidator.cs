using scalecloud_scale_agent.Model;

namespace scalecloud_scale_agent.Settings.Validation
{
    public interface IAgentSettingsValidator
    {
        ValidationResult Validate(
            AgentSettings settings);
    }
}