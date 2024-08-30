namespace TaskBox.Application.DTOs
{
    public class ListTaskDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsArchived { get; set; }
    }
}
