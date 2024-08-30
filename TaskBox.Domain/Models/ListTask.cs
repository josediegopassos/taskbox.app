namespace TaskBox.Domain.Models
{
    public partial class ListTask : BaseEntity
    {
        public string? Title {  get; private set; }
        public string? Description { get; private set; }
        public bool IsArchived { get; private set; }
        public Guid? CreatorUserId { get; private set; }

        public virtual User? CreatorUser { get; private set; }

        public virtual ICollection<Task>? Tasks { get; private set; }
    }
}
