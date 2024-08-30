namespace TaskBox.Domain.Models
{
    public partial class Task : BaseEntity
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime? TargetDate { get; private set; }
        public bool? IsArchived {  get; private set; }
        public Guid? ResponsibleUserId { get; private set; }
        public Guid ListTaskId { get; private set; }
        public Guid CreatorUserId { get; private set; }

        public virtual User? CreatorUser { get; private set; }
        public virtual User? ResponsibleUser { get; private set; }
        public virtual ListTask? ListTask { get; private set; }

        public virtual ICollection<TaskMarker>? TaskMarkers { get; private set; }
    }
}
