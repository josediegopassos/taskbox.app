namespace TaskBox.Domain.Models
{
    public partial class TaskMarker : BaseEntity
    {
        public Guid TaskId { get; private set; }
        public Guid MarkerId { get; private set; }

        public virtual Task? Task { get; private set; }
        public virtual Marker? Marker { get; private set; }
    }
}
