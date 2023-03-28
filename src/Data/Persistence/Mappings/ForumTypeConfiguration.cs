using drielnox.Forum.Business.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Persistence.Mappings
{
    internal sealed class ForumTypeConfiguration : EntityTypeConfiguration<Forum>
    {
        public ForumTypeConfiguration()
        {
            ToTable("Forums");

            HasKey(
                x => x.Identifier, 
                x => x.HasName("PK_Forums").IsClustered()
            );

            Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .HasColumnName("name")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.Administrator)
                .HasColumnName("admin")
                .IsUnicode(false)
                .HasMaxLength(100)
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
                .IsRequired();
            Property(x => x.AmendedAt)
                .HasColumnName("amended_at")
                .IsRequired();
            Property(x => x.AmendedBy)
                .HasColumnName("amended_by")
            .IsRequired();

            HasMany(x => x.Discussions)
                .WithRequired(x => x.Forum)
                .HasForeignKey(x => x.ForumId);
        }
    }
}
