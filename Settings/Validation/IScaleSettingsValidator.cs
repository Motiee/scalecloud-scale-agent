using scalecloud_scale_agent.Model;

namespace scalecloud_scale_agent.Settings.Validation
{
    public interface IScaleSettingsValidator
    {
        ValidationResult Validate(ScaleSettings settings);
    }
}