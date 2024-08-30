using Microsoft.EntityFrameworkCore;
using TaskBox.Domain.Interfaces.Repositories.Base;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context;

namespace TaskBox.Infra.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected TaskBoxDbContext _dataContext;
        protected DbSet<TEntity> _dbSet { get; set; }

        public BaseRepository(TaskBoxDbContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity obj)
        {
            await _dataContext.Set<TEntity>().AddAsync(obj);
            return obj;
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _dataContext.Entry(obj).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> RemoveAsync(TEntity obj)
        {
            _dataContext.Set<TEntity>().Remove(obj);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
