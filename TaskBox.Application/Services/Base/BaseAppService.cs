using TaskBox.Domain.Interfaces;
using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Notifications;

namespace TaskBox.Application.Services.Base
{
    public abstract class BaseAppService
    {
        protected IHandler<DomainNotification> Notifications { get; }
        private readonly IUnitOfWork _unitOfWork;

        public BaseAppService(IHandler<DomainNotification> notifications, IUnitOfWork unitOfWork)
        {
            Notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            if (Notifications.HasNotifications())
            {
                return false;
            }

            return _unitOfWork.Commit();
        }

        protected async Task<bool> CommitAsync()
        {
            if (Notifications.HasNotifications())
            {
                return false;
            }

            return await _unitOfWork.CommitAsync();
        }
    }
}
