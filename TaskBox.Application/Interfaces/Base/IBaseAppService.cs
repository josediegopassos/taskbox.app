namespace TaskBox.Application.Interfaces.Base
{
    public interface IBaseAppService<TDto> : IDisposable
        where TDto : class, new()
    {
        Task<TDto> CreateAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto, Guid id);
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
    }
}
