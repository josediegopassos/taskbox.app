using TaskBox.Domain.Models;

namespace TaskBox.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task<bool> RemoveAsync(TEntity obj);
    }
}
