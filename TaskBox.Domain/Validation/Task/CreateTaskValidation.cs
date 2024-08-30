using TaskBox.Domain.Interfaces.Validation;

namespace TaskBox.Domain.Validation.Task
{
    public class CreateTaskValidation : TaskValidation, IRegisterValidation<Models.Task>
    {
        public CreateTaskValidation()
        {
            ValidateListTaskId();
        }
    }
}
