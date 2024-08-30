using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Infra.Data.Context;
using TaskBox.Infra.Data.Repositories.Base;

namespace TaskBox.Infra.Data.Repositories
{
    public class TaskRepository : BaseRepository<Domain.Models.Task>, ITaskRepository
    {
        public TaskRepository(TaskBoxDbContext context) : base(context)
        {
        }
    }
}
