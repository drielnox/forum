using Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Persistence.Mappings
{
    internal sealed class CommentTypeConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentTypeConfiguration()
        {
            ToTable("Comments");

            HasKey(
                x => x.Identifier, 
                x => x.HasName("PK_Comments").IsClustered(false)
            );

            HasIndex(x => new { x.DiscussionId, x.Identifier })
                .HasName("UK_Comments_1")
                .IsUnique()
                .IsClustered();

            Property(x => x.DiscussionId)
                .HasColumnName("discussion_id")
                .IsRequired();
            Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Content)
                .HasColumnName("content")
                .IsUnicode(false)
                .HasMaxLength(400)
                .IsRequired();
            Property(x => x.Email)
                .HasColumnName("email")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .IsUnicode(false)
                .HasMaxLength(100)
            .IsRequired();

            HasRequired(x => x.RelatedDiscussion)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.DiscussionId);
        }
    }
}
