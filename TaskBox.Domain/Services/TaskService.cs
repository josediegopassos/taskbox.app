using System.Threading.Tasks;
using TaskBox.Domain.Interfaces;
using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Interfaces.Services;
using TaskBox.Domain.Models;
using TaskBox.Domain.Notifications;

namespace TaskBox.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IListTaskRepository _listTaskRepository;

        public TaskService(ITaskRepository taskRepository, IListTaskRepository listTaskRepository, IHandler<DomainNotification> notifications)
        {
            _taskRepository = taskRepository;
            _listTaskRepository = listTaskRepository;
        }

        public async Task<Models.Task> GetByIdAsync(Guid taskId)
        {
            return await this._taskRepository.GetByIdAsync(taskId);
        }

        public async Task<List<Models.Task>> GetAllAsync()
        {
            return await this._taskRepository.GetAllAsync();
        }

        public async Task<List<ListTask>> GetAllListTaskAsync()
        {
            return await this._listTaskRepository.GetAllAsync();
        }

        public async Task<Models.Task> CreateTaskAsync(Models.Task task)
        {
            var newTask = Models.Task.Create(
                task.Title,
                task.Description,
                task.TargetDate,
                task.ResponsibleUserId,
                task.ListTaskId,
                task.CreatorUserId);

            newTask = await this._taskRepository.CreateAsync(newTask);

            return newTask;
        }

        public async Task<Models.Task> UpdateTaskAsync(Guid id, Models.Task task)
        {
            var existTask = await this._taskRepository.GetByIdAsync(id);

            existTask.Update(
                task.Title,
                task.Description,
                task.TargetDate,
                task.ResponsibleUserId,
                task.ListTaskId);

            return await this._taskRepository.UpdateAsync(existTask);
        }

        public async Task<bool> RemoveTaskAsync(Guid taskId)
        {
            var existTask = await GetByIdAsync(taskId);
            existTask.Remove();

            await this._taskRepository.UpdateAsync(existTask);

            return true;
        }
    }
}
