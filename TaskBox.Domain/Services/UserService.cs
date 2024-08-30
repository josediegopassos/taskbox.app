using TaskBox.Domain.Interfaces;
using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Interfaces.Services;
using TaskBox.Domain.Models;
using TaskBox.Domain.Notifications;

namespace TaskBox.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IHandler<DomainNotification> notifications)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await this._userRepository.GetAllAsync();
        }
    }
}
