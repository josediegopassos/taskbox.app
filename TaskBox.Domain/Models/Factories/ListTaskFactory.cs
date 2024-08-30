namespace TaskBox.Domain.Models
{
    public partial class ListTask
    {
        public static ListTask Create(
            string? title,
            string? description,
            Guid creatorUserId)
        {
            return new ListTask
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CreatorUserId = creatorUserId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow.ToLocalTime(),
            };
        }

        public static ListTask Create(
            string? title,
            string? description)
        {
            return new ListTask
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public void Update(
           string? title,
           string? description,
           Guid creatorUserId)
        {
            Title = title;
            Description = description;
            CreatorUserId = creatorUserId;
            UpdatedAt = DateTime.UtcNow.ToLocalTime();
        }
    }
}
