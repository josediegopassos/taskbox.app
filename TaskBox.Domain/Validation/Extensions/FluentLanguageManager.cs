using FluentValidation;
using FluentValidation.Resources;
using System.Globalization;

namespace TaskBox.Domain.Validation.Extensions
{
    public class FluentLanguageManager : LanguageManager
    {
        public FluentLanguageManager()
        {
        }

        private static string GetMessage(string key, string propertyName, object parameters = null, CultureInfo culture = null)
        {
            var result = ValidatorOptions.Global.LanguageManager.GetString(key, culture);
            var messageBuilder = ValidatorOptions.Global.MessageFormatterFactory();
            messageBuilder.AppendArgument("PropertyName", propertyName);
            if (parameters != null)
            {
                parameters.GetType().GetProperties().ToList().ForEach(property =>
                {
                    messageBuilder.AppendArgument(property.Name, property.GetValue(parameters));
                });
            }
            result = messageBuilder.BuildMessage(result);

            return result;
        }

        public static string GetNotNullValidator(string propertyName)
        {
            return GetMessage("NotNullValidator", propertyName);
        }

        public static string GetEmailValidator(string propertyName)
        {
            return GetMessage("EmailValidator", propertyName);
        }

        public static string GetEqualValidator(string propertyName, object comparisonValue)
        {
            return GetMessage("EqualValidator", propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetLengthValidator(string propertyName, object minLength, object maxLength, object totalLength)
        {
            return GetMessage("LengthValidator", propertyName, new { MinLength = minLength, MaxLength = maxLength, TotalLength = totalLength });
        }

        public static string GetLengthValidator2(string propertyName, object minLength, object maxLength)
        {
            return GetMessage("LengthValidator2", propertyName, new { MinLength = minLength, MaxLength = maxLength });
        }

        public static string FormatValidator(string propertyName, object minLength, object maxLength)
        {
            return GetMessage("FormatValidator", propertyName, new { MinLength = minLength, MaxLength = maxLength });
        }

        public static string GetMinimumLengthValidator(string propertyName, object minLength, object totalLength)
        {
            return GetMessage("MinimumLengthValidator", propertyName, new { MinLength = minLength, TotalLength = totalLength });
        }

        public static string GetMinimumLengthValidator2(string propertyName, object minLength)
        {
            return GetMessage("MinimumLengthValidator2", propertyName, new { MinLength = minLength });
        }

        public static string GetMaximumLengthValidator(string propertyName, object maxLength, object totalLength)
        {
            return GetMessage("MaximumLengthValidator", propertyName, new { MinLength = maxLength, MaxLength = maxLength, TotalLength = totalLength });
        }

        public static string GetMaximumLengthValidator2(string propertyName, object maxLength)
        {
            return GetMessage("MaximumLengthValidator2", propertyName, new { MinLength = maxLength, MaxLength = maxLength });
        }

        public static string GetNotEmptyValidator(string propertyName)
        {
            return GetMessage("NotEmptyValidator", propertyName);
        }

        public static string GetNotEqualValidator(string propertyName, object comparisonValue)
        {
            return GetMessage("NotEqualValidator", propertyName, new { ComparisonValue = comparisonValue });
        }

        public static string GetNullValidator(string propertyName)
        {
            return GetMessage("NullValidator", propertyName);
        }

        public static string GetExactLengthValidator2(string propertyName, object maxLength)
        {
            return GetMessage("ExactLengthValidator2", propertyName, new { MaxLength = maxLength });
        }

        public static string GetUniqueValidator(string propertyName)
        {
            return GetMessage("UniqueValidator", propertyName);
        }
    }
}
