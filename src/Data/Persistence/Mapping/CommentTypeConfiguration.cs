using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Persistence.Mapping
{
    internal sealed class CommentTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        private static readonly List<Comment> _sampleData = new List<Comment>()
        {
            new Comment() 
            {
                Identifier = 1,
                DiscussionId = 1,
                Content = "Thanks",
                CreatedAt = new System.DateTime(2014, 4, 14, 21, 22, 0),
                CreatedBy = string.Empty,
                Email = "anon@gmail.com"
            },
            new Comment()
            {
                Identifier = 2,
                DiscussionId = 2,
                Content = "Well, the app could use a little more fine-tuning in general...",
                CreatedAt = new System.DateTime(2014, 4, 19, 18, 19, 13),
                CreatedBy = "Micheal",
                Email = "-"
            },
            new Comment()
            {
                Identifier = 3,
                DiscussionId = 1,
                Content = "Another Comment module test....",
                CreatedAt = new System.DateTime(2014, 4, 19, 18, 19, 13),
                CreatedBy = "Olu",
                Email = string.Empty
            },
            new Comment()
            {
                Identifier = 4,
                DiscussionId = 2,
                Content = "I totally agree...",
                CreatedAt = new System.DateTime(2015, 6, 10, 12, 25, 32),
                CreatedBy = "Otad",
                Email = "otad2mic@yahoo.com"
            },
            new Comment()
            {
                Identifier = 5,
                DiscussionId = 1,
                Content = "updated check",
                CreatedAt = new System.DateTime(2015, 7, 24, 12, 26, 40),
                CreatedBy = "Mike",
                Email = "m@t.com"
            }
        };

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => new { x.DiscussionId, x.Identifier })
                .HasName("PK_Comments");

            builder.Property(x => x.DiscussionId)
                .HasColumnName("discussion_id")
                .IsRequired();
            builder.Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Content)
                .HasColumnName("content")
                .IsUnicode(false)
                .HasMaxLength(400)
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
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.RelatedDiscussion)
                .WithMany(x => x.Comments)
                .HasPrincipalKey(x => x.Identifier)
                .HasForeignKey(x => x.DiscussionId);

            builder.HasData(_sampleData);
        }
    }
}
