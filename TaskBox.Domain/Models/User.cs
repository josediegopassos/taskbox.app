namespace TaskBox.Domain.Models
{
    public partial class User : BaseEntity
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }

        public Guid? CreatorUserId { get; private set; }

        public virtual User? CreatorUser { get; private set; }

        public virtual ICollection<User>? Users { get; private set; }
        public virtual ICollection<Board>? Boards { get; private set; }
        public virtual ICollection<ListTask>? ListTasks { get; private set; }
        public virtual ICollection<Marker>? Markers { get; private set; }
        public virtual ICollection<Task>? TasksForResponsibleUser {  get; private set; }
        public virtual ICollection<Task>? TasksForCreatorUser { get; private set; }
    }
}
