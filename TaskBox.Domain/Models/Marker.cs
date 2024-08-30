namespace TaskBox.Domain.Models
{
    public partial class Marker : BaseEntity
    {
        public string? Description { get; private set; }
        public Guid CreatorUserId { get; private set; }

        public virtual User? CreatorUser { get; private set; }

        public virtual ICollection<TaskMarker>? TaskMarkers { get; private set; }
    }
}
