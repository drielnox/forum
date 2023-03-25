using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;
using drielnox.Forum.Business.Entities;

namespace drielnox.Forum.Presetation.WebForms.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            using (var ctx = new ForumContext())
            {
                var userStore = new UserStore<User>(ctx);
                var manager = new UserManager<User>(userStore);

                var user = new User() { UserName = txtUserName.Text };
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    litStatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                }
                else
                {
                    litStatusMessage.Text = result.Errors.FirstOrDefault();
                }
            }
        }
    }
}