using drielnox.Forum.Business.Entities;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Mapping;

namespace Persistence
{
    public class ForumContext : DbContext
    {
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public ForumContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var conxStringBuilder = new SqlConnectionStringBuilder();
            conxStringBuilder.DataSource = "(LocalDB)\\MSSQLLocalDB";
            conxStringBuilder.IntegratedSecurity = true;

            optionsBuilder.UseSqlServer(conxStringBuilder.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiscussionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ForumTypeConfiguration());
        }
    }
}