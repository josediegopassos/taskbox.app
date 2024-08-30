using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context.Configurations.Base;

namespace TaskBox.Infra.Data.Context.Configurations
{
    internal class TaskMarkerConfiguration : BaseEntityTypeConfiguration<TaskMarker>
    {
        public override void Configure(EntityTypeBuilder<TaskMarker> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Task)
               .WithMany(x => x.TaskMarkers)
               .HasForeignKey(x => x.TaskId)
               .IsRequired(true);

            builder.HasOne(x => x.Marker)
               .WithMany(x => x.TaskMarkers)
               .HasForeignKey(x => x.MarkerId)
               .IsRequired(true);
        }
    }
}
