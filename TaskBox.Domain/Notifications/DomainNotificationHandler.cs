using TaskBox.Domain.Interfaces;
using TaskBox.Infra.CrossCutting.Logger.Interfaces;

namespace TaskBox.Domain.Notifications
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;
        private readonly ILoggerService _logger;
        private bool disposedValue;

        public DomainNotificationHandler(ILoggerService logger)
        {
            _notifications = new List<DomainNotification>();
            _logger = logger;
        }

        public void Handle(DomainNotification message)
        {
            if (_notifications == null)
            {
                ClearNotifications();
            }

            if (!_notifications.Any(x => x.Value.Trim().ToUpper().Equals(message.Value.Trim().ToUpper())))
            {
                _notifications.Add(message);
            }
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual Dictionary<string, string[]> GetNotificationsByKey()
        {
            var keys = _notifications.Select(s => s.Key).Distinct();
            var problemDetails = new Dictionary<string, string[]>();
            foreach (var key in keys)
            {
                problemDetails[key] = _notifications.Where(w => w.Key.Equals(key)).Select(s => s.Value).ToArray();
            }

            return problemDetails;
        }

        public virtual string GetNotificationMessages()
        {
            return _notifications.Select(x => x.Value).Aggregate((current, next) => $"{current} : {next}");
        }

        public virtual IEnumerable<DomainNotification> Notify()
            => GetNotifications();

        public virtual bool HasNotifications()
            => GetNotifications().Any();

        public void ClearNotifications()
        {
            _notifications = new List<DomainNotification>();
        }

        public void LogInfo(string infoMessage)
        {
            _logger.LogInfo(infoMessage);
        }

        public void LogWarning(string warningMessage)
        {
            _logger.LogWarning(warningMessage);
        }

        public void LogError(string errorMessage)
        {
            _logger.LogError(errorMessage);
        }

        public void LogError(Exception ex)
        {
            _logger.LogError(ex);
        }

        public void LogError(Exception ex, string errorMessage)
        {
            _logger.LogError(ex, errorMessage);
        }

        public void LogFatal(string errorMessage)
        {
            _logger.LogFatal(errorMessage);
        }

        public void LogFatal(Exception ex)
        {
            _logger.LogFatal(ex);
        }

        public void LogFatal(Exception ex, string errorMessage)
        {
            _logger.LogFatal(ex, errorMessage);
        }

        public async Task LogInfoAsync(string infoMessage)
        {
            await _logger.LogInfoAsync(infoMessage);
        }

        public async Task LogWarningAsync(string warningMessage)
        {
            await _logger.LogWarningAsync(warningMessage);
        }

        public async Task LogErrorAsync(string errorMessage)
        {
            await _logger.LogErrorAsync(errorMessage);
        }

        public async Task LogErrorAsync(Exception ex)
        {
            await _logger.LogErrorAsync(ex);
        }

        public async Task LogErrorAsync(Exception ex, string errorMessage)
        {
            await _logger.LogErrorAsync(ex, errorMessage);
        }

        public async Task LogFatalAsync(string errorMessage)
        {
            await _logger.LogFatalAsync(errorMessage);
        }

        public async Task LogFatalAsync(Exception ex)
        {
            await _logger.LogFatalAsync(ex);
        }

        public async Task LogFatalAsync(Exception ex, string errorMessage)
        {
            await _logger.LogFatalAsync(ex, errorMessage);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    ClearNotifications();

                _notifications = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
