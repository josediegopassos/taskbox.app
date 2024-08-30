using TaskBox.Domain.Interfaces.Services.Base;
using TaskBox.Domain.Models;

namespace TaskBox.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<List<User>> GetAllAsync();
    }
}
