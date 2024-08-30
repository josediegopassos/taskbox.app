using TaskBox.Domain.Interfaces.Services.Base;
using TaskBox.Domain.Models;

namespace TaskBox.Domain.Interfaces.Services
{
    public interface ITaskService : IBaseService<Models.Task>
    {
        Task<Models.Task> GetByIdAsync(Guid taskId);
        Task<List<Models.Task>> GetAllAsync();
        Task<List<ListTask>> GetAllListTaskAsync();
        Task<Models.Task> CreateTaskAsync(Models.Task task);
        Task<Models.Task> UpdateTaskAsync(Guid id, Models.Task task);
        Task<bool> RemoveTaskAsync(Guid taskId);
    }
}
