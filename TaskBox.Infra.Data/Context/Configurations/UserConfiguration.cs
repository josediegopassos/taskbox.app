using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context.Configurations.Base;

namespace TaskBox.Infra.Data.Context.Configurations
{
    internal class UserConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.Email)
               .HasMaxLength(200)
               .IsRequired(true);

            builder.HasOne(x => x.CreatorUser)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.CreatorUserId);
        }
    }
}
