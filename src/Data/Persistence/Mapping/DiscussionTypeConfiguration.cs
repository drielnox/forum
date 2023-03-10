using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Persistence.Mapping
{
    internal sealed class DiscussionTypeConfiguration : IEntityTypeConfiguration<Discussion>
    {
        private static readonly List<Discussion> _sampleData = new List<Discussion>()
        {
            new Discussion()
            {
                Identifier = 1,
                ForumId = 1,
                Subject = "Greetings",
                Content = "This is to welcome all TechOps Members to this forum...",
                CategoryId = 1,
                ViewCount = 31,
                CreatedAt = new DateTime(2014, 4, 14, 21, 16, 0),
                CreatedBy = "Micheal"
            },
            new Discussion()
            {
                Identifier = 2,
                ForumId = 1,
                Subject = "Testing New Discussion Module",
                Content = "Hi Team,\r\n\r\nHere\'s another discussion startup to test the functionality of this module over a web browser. Kindly comment on the output format or any amendments that could be added. Thanks all...",
                CategoryId = 2,
                ViewCount = 33,
                CreatedAt = new DateTime(2014, 4, 19, 0, 53, 33),
                CreatedBy = "mtadese"
            },
            new Discussion()
            {
                Identifier = 3,
                ForumId = 2,
                Subject = "Starting a discussion",
                Content = "Testing the discussion module after further amendments. Thanks",
                CategoryId = 3,
                ViewCount = 8,
                CreatedAt = new DateTime(2015, 7, 24, 12, 32, 55),
                CreatedBy = "mtadese"
            }
        };

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

            builder.HasOne(x => x.Forum)
                .WithMany(x => x.Discussions)
                .HasPrincipalKey(x => x.Identifier)
                .HasForeignKey(x => x.ForumId);
            builder.HasOne(x => x.Category)
                .WithMany()
                .HasPrincipalKey(x => x.Identifier)
                .HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.RelatedDiscussion)
                .HasPrincipalKey(x => x.Identifier)
                .HasForeignKey(x => x.DiscussionId);

            builder.HasData(_sampleData);
        }
    }
}
