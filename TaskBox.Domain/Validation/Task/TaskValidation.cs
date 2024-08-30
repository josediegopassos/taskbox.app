using TaskBox.Domain.Validation.Base;
using TaskBox.Domain.Validation.Extensions;

namespace TaskBox.Domain.Validation.Task
{
    public class TaskValidation : BaseValidation<Models.Task>
    {
        protected void ValidateListTaskId()
        {
            RuleFor(x => x.ListTaskId)
                .IsGuid();
        }
    }
}
