using drielnox.Forum.Business.Entities;
using Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence.Initializers;
using Persistence.Mappings;
using System;
using System.Data.Entity;

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

#if DEBUG
            Database.Log = Console.Write;
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CommentTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new DiscussionTypeConfiguration());
            modelBuilder.Configurations.Add(new ForumTypeConfiguration());
        }
    }
}