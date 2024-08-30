using FluentValidation.Results;
using TaskBox.Domain.Models;

namespace TaskBox.Domain.Interfaces.Validation.Base
{
    public interface IBaseValidation<TEntity>
        where TEntity : BaseEntity
    {
        ValidationResult IsValid(TEntity entity, TEntity oldEntity);
        Task<ValidationResult> IsValidAsync(TEntity entity, TEntity oldEntity);
    }
}
