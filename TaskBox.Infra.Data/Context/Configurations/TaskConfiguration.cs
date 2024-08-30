using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBox.Infra.Data.Context.Configurations.Base;

namespace TaskBox.Infra.Data.Context.Configurations
{
    internal class TaskConfiguration : BaseEntityTypeConfiguration<Domain.Models.Task>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                 .HasMaxLength(200)
                 .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.HasOne(x => x.CreatorUser)
               .WithMany(x => x.TasksForCreatorUser)
               .HasForeignKey(x => x.CreatorUserId)
               .IsRequired(true);

            builder.HasOne(x => x.ResponsibleUser)
               .WithMany(x => x.TasksForResponsibleUser)
               .HasForeignKey(x => x.ResponsibleUserId);

            builder.HasOne(x => x.ListTask)
               .WithMany(x => x.Tasks)
               .HasForeignKey(x => x.ListTaskId)
               .IsRequired(true);
        }
    }
}
