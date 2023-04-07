using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drielnox.Forum.Presetation.WebForms.Accounts.Users
{
    public partial class View : System.Web.UI.Page
    {
        private string _userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _userId = Request.QueryString.Get("UserId");
            if (string.IsNullOrWhiteSpace(_userId))
            {
                System.Diagnostics.Trace.TraceError("UserId is null or empty.");
            }

            using (var ctx = new ForumContext())
            {
                var userStore = new UserStore<User>(ctx);
                var userManager = new UserManager<User>(userStore);

                var user = userManager.FindById(_userId);
                if (user == null)
                {
                    System.Diagnostics.Trace.TraceError("User '{0}' not founded.", _userId);
                }

                LoadUser(user);

                var roleStore = new RoleStore<IdentityRole>(ctx);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var roles = roleManager.Roles
                    .Where(x => x.Users
                        .Any(y => y.UserId == _userId)
                    )
                    .ToList();

                LoadUserRoles(roles);
            }
        }

        private void LoadUser(User user)
        {
            litUserName.Text = user.UserName;

            txtUserId.Text = user.Id;
            txtUserName.Text = user.UserName;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
        }

        private void LoadUserRoles(IEnumerable<IdentityRole> roles)
        {
            gvRoles.DataSource = roles;
            gvRoles.DataBind();
        }
    }
}