using FluentValidation;
using FluentValidation.Results;
using TaskBox.Domain.Models;
using TaskBox.Domain.Validation.Extensions;

namespace TaskBox.Domain.Validation.Base
{
    public abstract class BaseValidation<TEntity> : AbstractValidator<TEntity>
        where TEntity : BaseEntity
    {

        protected void ValidateId() => RuleFor(x => x.Id).NotNull().IsGuid();

        public virtual async Task<ValidationResult> IsValidAsync(TEntity entity, TEntity oldEntity = null)
        {
            var context = new ValidationContext<TEntity>(entity);
            context.RootContextData.Add("oldEntity", oldEntity);
            return await ValidateAsync(context);
        }

        public virtual ValidationResult IsValid(TEntity entity, TEntity oldEntity = null)
        {
            var context = new ValidationContext<TEntity>(entity);
            context.RootContextData.Add("oldEntity", oldEntity);
            return Validate(context);
        }
        protected TEntity OldEntity(ValidationContext<TEntity> context) => (TEntity)context.RootContextData["oldEntity"];
    }
}
