using BlogSystem.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Configurations
{
    public class TagConfigurations : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasIndex(x => x.Id)
                .IsClustered(false);

            builder.Property(c => c.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1024)
                .IsRequired();
        }
    }
}
