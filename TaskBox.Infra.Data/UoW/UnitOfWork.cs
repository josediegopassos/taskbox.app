using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Infra.Data.Context;

namespace TaskBox.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskBoxDbContext _context;

        public UnitOfWork(TaskBoxDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return (rowsAffected > 0);
        }

        public async Task<bool> CommitAsync()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
