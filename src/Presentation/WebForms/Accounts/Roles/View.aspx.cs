using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drielnox.Forum.Presetation.WebForms.Accounts.Roles
{
    public partial class View : System.Web.UI.Page
    {
        private readonly ILogger _logger;
        private string _roleId;

        public View()
        {
            _logger = Logging.CreateLogger<View>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _roleId = Request.QueryString.Get("RoleId");
            if (string.IsNullOrWhiteSpace(_roleId))
            {
                _logger.LogError("RoleId is null or empty.");
            }

            using (var ctx = new ForumContext())
            {
                var roleStore = new RoleStore<IdentityRole>(ctx);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var role = roleManager.FindById(_roleId);
                if (role == null)
                {
                    _logger.LogError("Role '{0}' not founded.", _roleId);
                }

                LoadRole(role);

                var userStore = new UserStore<User>(ctx);
                var userManager = new UserManager<User>(userStore);

                var users = userManager.Users
                    .Where(x => x.Roles
                        .Any(y => y.RoleId == _roleId)
                    )
                    .ToList();

                LoadUsersInRole(users);
            }
        }

        private void LoadRole(IdentityRole role)
        {
            litRoleName.Text = role.Name;

            txtRoleId.Text = role.Id;
            txtRoleName.Text = role.Name;
        }

        private void LoadUsersInRole(ICollection<User> users)
        {
            gvUsersInRole.DataSource = users;
            gvUsersInRole.DataBind();
        }
    }
}