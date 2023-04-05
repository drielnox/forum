using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drielnox.Forum.Presetation.WebForms.Accounts.Roles
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void LoadRoles()
        {
            using (var ctx = new ForumContext())
            {
                var roleStore = new RoleStore<IdentityRole>(ctx);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var roles = roleManager.Roles.ToList();

                gvRoles.DataSource = roles;
                gvRoles.DataBind();
            }
        }
    }
}