using System.ComponentModel.DataAnnotations;

namespace TaskBox.Application.CustomAttributes
{
    public class MaxLengthValidationAttribute : MaxLengthAttribute
    {
        public MaxLengthValidationAttribute(int length)
            : base(length)
        {

        }
    }
}
