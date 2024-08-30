namespace TaskBox.Domain.Models
{
    public partial class User
    {
        public static User Create(
            string? name,
            string? email)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                IsActive = true,
                CreatedAt = DateTime.UtcNow.ToLocalTime(),
            };
        }

        public static User Create(
            string? name,
            string? email,
            Guid creatorUserId)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,                
                CreatedAt = DateTime.UtcNow,
                CreatorUserId = creatorUserId
            };
        }


        public void Update(
           string? name,
           string? email,
           Guid creatorUserId)
        {
            Name = name;
            Email = email;
            CreatorUserId = creatorUserId;
            UpdatedAt = DateTime.UtcNow.ToLocalTime();
        }
    }
}
