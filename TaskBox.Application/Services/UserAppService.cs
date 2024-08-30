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
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserAppService(IHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork,
            IUserService userService, 
            IMapper mapper)
            : base(notifications, unitOfWork)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var userEntity = await _userService.GetAllAsync();
            return _mapper.Map<List<UserDto>>(userEntity);
        }
    }
}
