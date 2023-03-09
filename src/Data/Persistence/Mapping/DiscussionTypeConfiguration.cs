using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    internal sealed class DiscussionTypeConfiguration : IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.ToTable("Discussions");

            builder.HasKey(x => new { x.ForumId, x.Identifier })
                .HasName("PK_Discussions");

            builder.Property(x => x.ForumId)
                .HasColumnName("forum_id")
                .IsRequired();
            builder.Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Subject)
                .HasColumnName("subject")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Content)
                .HasColumnName("content")
                .IsUnicode(false)
                .HasMaxLength(700)
                .IsRequired();
            builder.Property(x => x.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();
            builder.Property(x => x.ViewCount)
                .HasColumnName("view_count")
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            builder.Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Forum);
            builder.HasOne(x => x.Category);
            builder.HasMany(x => x.Comments);
        }
    }
}
