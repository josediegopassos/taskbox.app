using TaskBox.Application.DTOs;

namespace TaskBox.Application.Interfaces
{
    public interface ITaskAppService
    {
        Task<TaskDto> GetByIdAsync(Guid taskId);
        Task<List<TaskDto>> GetAllAsync();
        Task<List<ListTaskDto>> GetAllListTaskAsync();
        Task<TaskDto> CreateAsync(RegisterTaskDto taskDto);
        Task<RegisterTaskDto> UpdateAsync(RegisterTaskDto taskDto, Guid taskId);
        Task<bool> RemoveAsync(Guid taskId);
    }
}
