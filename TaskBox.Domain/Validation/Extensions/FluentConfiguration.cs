using FluentValidation;
using System.Globalization;

namespace TaskBox.Domain.Validation.Extensions
{
    public static class FluentConfiguration
    {
        public static void ConfigureFluent()
        {
            ValidatorOptions.Global.LanguageManager = new FluentLanguageManager
            {
                Enabled = false,
                Culture = new CultureInfo("en")
            };
        }
    }
}
