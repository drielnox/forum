using Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Persistence.Mappings
{
    internal sealed class CategoryTypeConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryTypeConfiguration()
        {
            ToTable("Categories");

            HasKey(
                x => x.Identifier, 
                x => x.HasName("PK_Categories").IsClustered()
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
        }
    }
}
