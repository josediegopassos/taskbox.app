using TaskBox.Application.DTOs;

namespace TaskBox.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<List<UserDto>> GetAll();
    }
}
