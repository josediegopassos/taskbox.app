using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context.Configurations.Base;

namespace TaskBox.Infra.Data.Context.Configurations
{
    internal class MarkerConfiguration : BaseEntityTypeConfiguration<Marker>
    {
        public override void Configure(EntityTypeBuilder<Marker> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired(true);

            builder.HasOne(x => x.CreatorUser)
               .WithMany(x => x.Markers)
               .HasForeignKey(x => x.CreatorUserId)
               .IsRequired(true);
        }
    }
}
