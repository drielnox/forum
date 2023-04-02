using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Persistence.Initializers
{
    internal class DevelopmentInitializer : DropCreateDatabaseAlways<ForumContext>
    {
        private static readonly List<Category> _sampleCategoryData = new List<Category>()
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

        private static readonly List<IdentityRole> _sampleRoleData = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Name = "Administrator"
            },
            new IdentityRole()
            {
                Name = "User"
            }
        };

        private static readonly List<User> _sampleUserData = new List<User>()
        {
            new User()
            {
                FirstName = "Micheal",
                LastName = "Tadese",
                Email = "mtadese@gmail.com",
                UserName = "mtadese",
            },
            new User()
            {
                FirstName = "Otad",
                LastName = "**",
                Email = "mtadese@gmail.com",
                UserName = "otad"
            },
            new User()
            {
                FirstName = "User",
                LastName = "Pass",
                Email = "mtadese@gmail.com",
                UserName = "user"
            }
        };

        private static readonly List<Comment> _sampleCommentData = new List<Comment>()
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

        private static readonly List<Discussion> _sampleDiscussionData = new List<Discussion>()
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

        private static readonly List<Forum> _sampleForumData = new List<Forum>()
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

        protected override void Seed(ForumContext context)
        {
            base.Seed(context);

            context.Categories.AddRange(_sampleCategoryData);

            CreateRoles(context);
            CreateUsers(context);
            AssignRoles(context);

            _sampleDiscussionData[0].Category = _sampleCategoryData[0];
            _sampleDiscussionData[1].Category = _sampleCategoryData[1];
            _sampleDiscussionData[2].Category = _sampleCategoryData[2];

            _sampleDiscussionData[0].Comments.Add(_sampleCommentData[0]);
            _sampleDiscussionData[1].Comments.Add(_sampleCommentData[1]);
            _sampleDiscussionData[0].Comments.Add(_sampleCommentData[2]);
            _sampleDiscussionData[1].Comments.Add(_sampleCommentData[3]);
            _sampleDiscussionData[0].Comments.Add(_sampleCommentData[4]);

            _sampleForumData[0].Discussions.Add(_sampleDiscussionData[0]);
            _sampleForumData[0].Discussions.Add(_sampleDiscussionData[1]);
            _sampleForumData[1].Discussions.Add(_sampleDiscussionData[2]);

            context.Forums.AddRange(_sampleForumData);

            context.SaveChanges();
        }

        private static void AssignRoles(ForumContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            userManager.AddToRole(_sampleUserData[0].Id, "Administrator");
            userManager.AddToRole(_sampleUserData[1].Id, "Administrator");
            userManager.AddToRole(_sampleUserData[2].Id, "User");

            context.SaveChanges();
        }

        private static void CreateUsers(ForumContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            foreach (var sampleUser in _sampleUserData)
            {
                userManager.Create(sampleUser, "asdqwe123");
            }

            context.SaveChanges();
        }

        private static void CreateRoles(ForumContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (var sampleRole in _sampleRoleData)
            {
                roleManager.Create(sampleRole);
            }

            context.SaveChanges();
        }
    }
}
