namespace TaskBox.Domain.Interfaces
{
    public interface IDomainEvent
    {
        int Version { get; }
        DateTime OccurrenceDate { get; }
    }
}
