using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence.Initializers;
using Persistence.Mappings;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Persistence
{
    public class ForumContext : IdentityDbContext<User>
    {
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public ForumContext()
            : base("name=LocalDbConnection")
        {
            Database.SetInitializer(new DevelopmentInitializer());

            Database.Log = x => Debug.Write(x);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CommentTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new DiscussionTypeConfiguration());
            modelBuilder.Configurations.Add(new ForumTypeConfiguration());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditable)
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((IAuditable)entityEntry.Entity).CreatedBy = System.Web.HttpContext.Current?.User?.Identity?.Name ?? "Forum";
                }
                else
                {
                    Entry((IAuditable)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((IAuditable)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                ((IAuditable)entityEntry.Entity).AmendedAt = DateTime.UtcNow;
                ((IAuditable)entityEntry.Entity).AmendedBy = System.Web.HttpContext.Current?.User?.Identity?.Name ?? "Forum";
            }

            return base.SaveChanges();
        }
    }
}