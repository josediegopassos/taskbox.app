using TaskBox.Domain.Interfaces.Validation.Base;
using TaskBox.Domain.Models;

namespace TaskBox.Domain.Interfaces.Validation
{
    public interface IRegisterValidation<TEntity> : IBaseValidation<TEntity> where TEntity : BaseEntity
    {
    }
}
