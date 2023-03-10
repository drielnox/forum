using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Persistence.Mapping
{
    internal sealed class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        private static readonly List<Category> _sampleData = new List<Category>()
        { 
            new Category()
            { 
                Identifier = 1,
                Name = "Faith and Confessions"
            },
            new Category()
            {
                Identifier = 2,
                Name = "Health, Fitness and Wellness"
            },
            new Category()
            {
                Identifier = 3,
                Name = "Charity and Hospitality"
            },
            new Category()
            {
                Identifier = 4,
                Name = "Advertising and Public Awareness"
            },
            new Category()
            {
                Identifier = 5,
                Name = "Information Technology"
            }
        };

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Identifier)
                .HasName("PK_Categories");

            builder.Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(_sampleData);
        }
    }
}
