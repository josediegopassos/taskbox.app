using TaskBox.Application.CustomAttributes;

namespace TaskBox.Application.DTOs
{
    public class RegisterTaskDto
    {
        [RequiredValidation]
        [MaxLengthValidation(100)]
        public string? Title { get; set; }

        [MaxLengthValidation(200)]
        public string? Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public bool? IsArchived { get; set; }
        public Guid? ResponsibleUserId { get; set; }

        [RequiredGuidValidation]
        public Guid ListTaskId { get; set; }

        [RequiredGuidValidation]
        public Guid CreatorUserId { get; set; }
    }
}
