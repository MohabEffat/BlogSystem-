using BlogSystem.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Configurations
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasIndex(x => x.Id)
                .IsClustered(false);

            builder.HasOne(pt => pt.Tag)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => new {x.PostId, x.TagId} );
        }
    }
}
