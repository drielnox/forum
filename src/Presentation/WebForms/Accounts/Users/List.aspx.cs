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
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var ctx = new ForumContext())
            {
                var userStore = new UserStore<User>(ctx);
                var userManager = new UserManager<User>(userStore);

                var users = userManager.Users.ToList();

                gvUsers.DataSource = users;
                gvUsers.DataBind();
            }
        }
    }
}