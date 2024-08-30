using System.ComponentModel.DataAnnotations;
using TaskBox.Application.Resources;

namespace TaskBox.Application.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredValidationAttribute : RequiredAttribute
    {
        public RequiredValidationAttribute()
        {
            ErrorMessage = AnnotationMessages.Required;
            AllowEmptyStrings = false;
        }
    }
}
