namespace TaskBox.Domain.Models
{
    public partial class Task
    {
        public Task() { }

        public static Task Create(
            string? title,
            string? description,
            DateTime? targetDate,
            Guid? responsibleUserId,
            Guid listTaskId,
            Guid creatorUserId)
        {
            return new Task
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                TargetDate = targetDate,
                ResponsibleUserId = responsibleUserId,
                ListTaskId = listTaskId,
                CreatorUserId = creatorUserId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow.ToLocalTime(),
            };
        }

        public void Update(
           string? title,
           string? description,
           DateTime? targetDate,
           Guid? responsibleUserId,
           Guid listTaskId)
        {
            Title = title;
            Description = description;
            TargetDate = targetDate;
            ResponsibleUserId = responsibleUserId;
            ListTaskId = listTaskId;
            UpdatedAt = DateTime.UtcNow.ToLocalTime();
        }

        public void Archive(bool isArchived)
        {
            IsArchived = isArchived;
        }

        public void Remove()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow.ToLocalTime();
        }

        public void SetResponsibleUser(Guid responsibleUserId)
        {
            ResponsibleUserId = responsibleUserId;
        }
    }
}
