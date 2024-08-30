using TaskBox.Infra.CrossCutting.Extensions;

namespace TaskBox.Application.CustomAttributes
{
    public class RequiredGuidValidationAttribute : RequiredValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var guid = (Guid?)value;
            bool isValid = guid.HasValue ? guid.Value != default : false;

            return (isValid && Guid.TryParse(guid.Value.ToString(), out var result) && result != default && result.ToString().IsGuid());
        }
    }
}
