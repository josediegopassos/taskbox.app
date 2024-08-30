using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context.Configurations.Base;

namespace TaskBox.Infra.Data.Context.Configurations
{
    public class BoardConfiguration : BaseEntityTypeConfiguration<Board>
    {
        public override void Configure(EntityTypeBuilder<Board> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.HasOne(x => x.CreatorUser)
                .WithMany(x => x.Boards)
                .HasForeignKey(x => x.CreatorUserId)
                .IsRequired(true);
        }
    }
}
