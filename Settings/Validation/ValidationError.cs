namespace scalecloud_scale_agent.Settings.Validation
{
    public class ValidationError
    {
        public string PropertyName { get; }

        public string Message { get; }

        public ValidationError(
            string propertyName,
            string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public override string ToString()
        {
            return $"{PropertyName}: {Message}";
        }
    }
}