using scalecloud_scale_agent.Model;

namespace scalecloud_scale_agent.Settings.Validation
{
    public class ScaleSettingsValidator :
        IScaleSettingsValidator
    {
        public ValidationResult Validate(
            ScaleSettings settings)
        {
            var result =
                new ValidationResult();

            if (settings == null)
            {
                result.Add(
                    "",
                    "Settings is null.");

                return result;
            }

            if (!settings.Enabled)
                return result;

            if (string.IsNullOrWhiteSpace(
                settings.SerialPort.PortName))
            {
                result.Add(
                    nameof(settings.SerialPort.PortName),
                    "COM Port is required.");
            }

            if (settings.SerialPort.BaudRate <= 0)
            {
                result.Add(
                    nameof(settings.SerialPort.BaudRate),
                    "Invalid BaudRate.");
            }

            if (string.IsNullOrWhiteSpace(
                settings.Protocol.ProtocolId))
            {
                result.Add(
                    nameof(settings.Protocol.ProtocolId),
                    "Protocol is required.");
            }

            return result;
        }
    }
}