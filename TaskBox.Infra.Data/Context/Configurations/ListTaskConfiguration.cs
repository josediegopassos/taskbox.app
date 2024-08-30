using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context.Configurations.Base;

namespace TaskBox.Infra.Data.Context.Configurations
{
    internal class ListTaskConfiguration : BaseEntityTypeConfiguration<ListTask>
    {
        public override void Configure(EntityTypeBuilder<ListTask> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.HasOne(x => x.CreatorUser)
                .WithMany(x => x.ListTasks)
                .HasForeignKey(x => x.CreatorUserId);
        }
    }
}
