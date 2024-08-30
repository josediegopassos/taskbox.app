using TaskBox.Domain.Validation.Extensions;

namespace TaskBox.Application.Resources
{
    public static class AnnotationMessages
    {
        public static string Required => FluentLanguageManager.GetNotNullValidator("{0}");
    }
}
