using AutoMapper;
using TaskBox.Application.DTOs;
using TaskBox.Application.Interfaces;
using TaskBox.Application.Services.Base;
using TaskBox.Domain.Interfaces;
using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Interfaces.Services;
using TaskBox.Domain.Notifications;

namespace TaskBox.Application.Services
{
    public class TaskAppService : BaseAppService, ITaskAppService
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskAppService(IHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork, 
            ITaskService taskService, 
            IMapper mapper)
            : base(notifications, unitOfWork)
        {
            this._taskService = taskService;
            this._mapper = mapper;
        }

        public async Task<TaskDto> GetByIdAsync(Guid taskId)
        {
            var taskEntity = await _taskService.GetByIdAsync(taskId);
            return _mapper.Map<TaskDto>(taskEntity);
        }

        public async Task<List<TaskDto>> GetAllAsync()
        {
            var taskEntity = await _taskService.GetAllAsync();
            return _mapper.Map<List<TaskDto>>(taskEntity);
        }

        public async Task<List<ListTaskDto>> GetAllListTaskAsync()
        {
            var listTaskEntity = await _taskService.GetAllListTaskAsync();
            return _mapper.Map<List<ListTaskDto>>(listTaskEntity);
        }

        public async Task<RegisterTaskDto> UpdateAsync(RegisterTaskDto taskDto, Guid taskId)
        {
            var taskModel = _mapper.Map<Domain.Models.Task>(taskDto);
            taskModel = await _taskService.UpdateTaskAsync(taskId, taskModel);
            await CommitAsync();

            var registerTaskDto = _mapper.Map<RegisterTaskDto>(taskModel);

            return registerTaskDto;
        }

        public async Task<bool> RemoveAsync(Guid taskId)
        {
            return await _taskService.RemoveTaskAsync(taskId);
        }

        public async Task<TaskDto> CreateAsync(RegisterTaskDto taskDto)
        {
            var taskModel = _mapper.Map<Domain.Models.Task>(taskDto);
            taskModel = await _taskService.CreateTaskAsync(taskModel);
            await CommitAsync();

            var registerTaskDto = _mapper.Map<TaskDto>(taskModel);

            return registerTaskDto;
        }
    }
}
