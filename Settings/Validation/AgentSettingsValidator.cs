using scalecloud_scale_agent.Model;
using System;

namespace scalecloud_scale_agent.Settings.Validation
{
    public class AgentSettingsValidator
        : IAgentSettingsValidator
    {
        private readonly IScaleSettingsValidator
            _scaleValidator;

        public AgentSettingsValidator(
            IScaleSettingsValidator scaleValidator)
        {
            _scaleValidator = scaleValidator;
        }

        public ValidationResult Validate(
            AgentSettings settings)
        {
            var result = new ValidationResult();

            if (settings == null)
            {
                result.Add(
                    "",
                    "Settings is null.");

                return result;
            }

            Merge(
                result,
                "Channel1",
                _scaleValidator.Validate(
                    settings.Channel1));

            Merge(
                result,
                "Channel2",
                _scaleValidator.Validate(
                    settings.Channel2));

            ValidateDuplicatePorts(
                settings,
                result);

            return result;
        }

        private void ValidateDuplicatePorts(
            AgentSettings settings,
            ValidationResult result)
        {
            if (!settings.Channel1.Enabled ||
                !settings.Channel2.Enabled)
            {
                return;
            }

            string port1 =
                settings.Channel1.SerialPort.PortName;

            string port2 =
                settings.Channel2.SerialPort.PortName;

            if (String.IsNullOrWhiteSpace(port1) ||
                String.IsNullOrWhiteSpace(port2))
            {
                return;
            }

            if (String.Equals(
                port1,
                port2,
                StringComparison.OrdinalIgnoreCase))
            {
                result.Add(
                    "Channel2.SerialPort.PortName",
                    "COM Port is already used by Channel1.");
            }
        }

        private void Merge(
            ValidationResult target,
            string prefix,
            ValidationResult source)
        {
            foreach (var error in source.Errors)
            {
                target.Add(
                    $"{prefix}.{error.PropertyName}",
                    error.Message);
            }
        }
    }
}