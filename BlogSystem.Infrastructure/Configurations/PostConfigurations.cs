using BlogSystem.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Configurations
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.Property(x => x.Title)
                 .HasColumnType("NVARCHAR")
                 .HasMaxLength(1024)
                 .IsRequired();

            builder.Property(x => x.Content)
                 .HasColumnType("NVARCHAR")
                 .HasMaxLength(1024)
                 .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasComputedColumnSql("GETDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasComputedColumnSql("GETDATE()");

            builder.HasIndex(x => x.Id)
                .IsClustered(false);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Author)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(p => p.status)
                .HasConversion<string>();


        }
    }
}
