using drielnox.Forum.Business.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Persistence.Mappings
{
    internal sealed class DiscussionTypeConfiguration : EntityTypeConfiguration<Discussion>
    {
        public DiscussionTypeConfiguration()
        {
            ToTable("Discussions");

            HasKey(
                x => x.Identifier,
                x => x.HasName("PK_Discussions").IsClustered(false)
            );

            HasIndex(x => new { x.ForumId, x.Identifier })
                .HasName("UK_Discussions_1")
                .IsUnique()
                .IsClustered();

            Property(x => x.ForumId)
                .HasColumnName("forum_id")
                .IsRequired();
            Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Subject)
                .HasColumnName("subject")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.Content)
                .HasColumnName("content")
                .IsUnicode(false)
                .HasMaxLength(700)
                .IsRequired();
            Property(x => x.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();
            Property(x => x.ViewCount)
                .HasColumnName("view_count")
                .IsRequired();
            Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .IsUnicode(false)
                .HasMaxLength(100)
            .IsRequired();

            HasRequired(x => x.Forum)
                .WithMany(x => x.Discussions)
                .HasForeignKey(x => x.ForumId);
            HasRequired(x => x.Category)
                .WithMany(x => x.RelatedDiscussions)
                .HasForeignKey(x => x.CategoryId);
            HasMany(x => x.Comments)
                .WithRequired(x => x.RelatedDiscussion)
                .HasForeignKey(x => x.DiscussionId);
        }
    }
}
