namespace TaskBox.Domain.Models
{
    public partial class Board
    {
        public Board Create(
            string? title,
            string? description,
            Guid creatorUserId)
        {
            return new Board
            {
                Title = title,
                Description = description,
                CreatorUserId = creatorUserId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow.ToLocalTime(),
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
