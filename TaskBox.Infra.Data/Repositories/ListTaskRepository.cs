using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context;
using TaskBox.Infra.Data.Repositories.Base;

namespace TaskBox.Infra.Data.Repositories
{
    public class ListTaskRepository : BaseRepository<ListTask>, IListTaskRepository
    {
        public ListTaskRepository(TaskBoxDbContext context) : base(context)
        {
        }
    }
}
