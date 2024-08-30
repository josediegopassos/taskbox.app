namespace TaskBox.Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public bool? IsArchived { get; set; }

        public Guid? ResponsibleUserId { get; set; }
        public Guid ListTaskId { get; set; }
        public Guid CreatorUserId { get; set; }
    }
}
