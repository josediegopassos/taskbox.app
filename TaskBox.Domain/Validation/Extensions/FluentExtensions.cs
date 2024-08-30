using FluentValidation;

namespace TaskBox.Domain.Validation.Extensions
{
    public static class FluentExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> SetMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> options, string stringName)
            => options.WithMessage(ValidatorOptions.Global.LanguageManager.GetString(stringName));

        public static IRuleBuilderOptions<T, TProperty> SetMessageWithParameter<T, TProperty>(this IRuleBuilderOptions<T, TProperty> options, string stringName, string stringKey1, string stringValue1)
            => options.WithMessage(ValidatorOptions.Global.LanguageManager.GetString(stringName).Replace(stringKey1, stringValue1));

        public static IRuleBuilderOptions<T, Guid> IsGuid<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder
                .NotEqual(Guid.Empty).SetMessage("GuidValidator");
        }
    }
}
