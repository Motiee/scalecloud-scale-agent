using System.Collections.Generic;
using System.Linq;

namespace scalecloud_scale_agent.Settings.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors =
            new List<ValidationError>();

        public IReadOnlyList<ValidationError> Errors => _errors;

        public bool IsValid => !_errors.Any();

        public void Add(
            string property,
            string message)
        {
            _errors.Add(
                new ValidationError(
                    property,
                    message));
        }
    }
}