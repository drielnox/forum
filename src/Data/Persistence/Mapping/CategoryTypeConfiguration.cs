using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    internal sealed class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
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
        }
    }
}
