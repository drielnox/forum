using drielnox.Forum.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Persistence.Mapping
{
    internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly static List<User> _sampleData = new List<User>()
        {
            new User()
            {
                Identifier = 1,
                FirstName = "Micheal",
                LastName = "Tadese",
                Email = "mtadese@gmail.com",
                Password = "pass",
                UserName = "mtadese",
                Status = "admin"
            },
            new User()
            {
                Identifier = 2,
                FirstName = "Otad",
                LastName = "**",
                Email = "mtadese@gmail.com",
                Password = "pass",
                UserName = "otad",
                Status = "admin"
            },
            new User()
            {
                Identifier = 3,
                FirstName = "User",
                LastName = "Pass",
                Email = "mtadese@gmail.com",
                Password = "pass",
                UserName = "user",
                Status  ="default"
            }
        };

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Identifier)
                .HasName("PK_Users");

            builder.Property(x => x.Identifier)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.UserName)
                .HasColumnName("username")
                .IsUnicode(false)
                .HasMaxLength(45);
            builder.Property(x => x.FirstName)
                .HasColumnName("firstname")
                .IsUnicode(false)
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasColumnName("lastname")
                .IsUnicode(false)
                .HasMaxLength(50);
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasColumnName("password")
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Status)
                .HasColumnName("status")
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.HasData(_sampleData);
        }
    }
}
