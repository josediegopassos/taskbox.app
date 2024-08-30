namespace TaskBox.Domain.Models
{
    public partial class Marker
    {
        public Marker Create(
             string? description,
            Guid creatorUserId)
        {
            return new Marker
            {
                Description = description,
                CreatorUserId = creatorUserId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow.ToLocalTime(),
            };
        }

        public void Update(
           string? description,
           Guid creatorUserId)
        {
            Description = description;
            CreatorUserId = creatorUserId;
            UpdatedAt = DateTime.UtcNow.ToLocalTime();
        }
    }
}
