using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Persistence.Mapping
{
    internal sealed class ForumTypeConfiguration : IEntityTypeConfiguration<Forum>
    {
        private readonly static List<Forum> _sampleData = new List<Forum>()
        {
            new Forum()
            {
                Identifier = 1,
                Name = "Otad_Group",
                Administrator = "Otad",
                Email = "mt@gmail.com",
                CreatedAt = new System.DateTime(2014, 4, 14, 21, 7, 0),
                CreatedBy = "mtadese",
                AmendedAt = new System.DateTime(2015, 7, 22, 17, 57, 0),
                AmendedBy = "user"
            },
            new Forum()
            {
                Identifier = 2,
                Name = "dotNET Team",
                Administrator = "Micheal",
                Email = "mt@gmail.com",
                CreatedAt = new System.DateTime(2014, 4, 20, 1, 1, 0),
                CreatedBy = "mtadese",
                AmendedAt = new System.DateTime(2015, 7, 22, 17, 57, 0),
                AmendedBy = "user"
            }
        };

        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("Forums");

            builder.HasKey(x => x.Identifier)
                .HasName("PK_Forums");

            builder.Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Administrator)
                .HasColumnName("admin")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            builder.Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired();
            builder.Property(x => x.AmendedAt)
                .HasColumnName("amended_at")
                .IsRequired();
            builder.Property(x => x.AmendedBy)
                .HasColumnName("amended_by")
                .IsRequired();

            builder.HasMany(x => x.Discussions)
                .WithOne(x => x.Forum)
                .HasPrincipalKey(x => x.Identifier)
                .HasForeignKey(x => x.ForumId);

            builder.HasData(_sampleData);
        }
    }
}
