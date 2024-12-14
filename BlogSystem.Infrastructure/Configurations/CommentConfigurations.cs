using BlogSystem.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasIndex(x => x.Id)
                .IsClustered(false);

            builder.HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);  

            builder.Property(x => x.Content)
                 .HasColumnType("NVARCHAR")
                 .HasMaxLength(1024)
                 .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasComputedColumnSql("GETDATE()");

        }
    }
}
