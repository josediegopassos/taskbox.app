namespace TaskBox.Domain.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        Dictionary<string, string[]> GetNotificationsByKey();
        List<T> GetNotifications();
        string GetNotificationMessages();
        void ClearNotifications();
    }
}
