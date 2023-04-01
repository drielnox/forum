using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Persistence;
using System;
using System.Web;
using System.Web.UI;

namespace drielnox.Forum.Presetation.WebForms.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    litStatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                    phLoginStatus.Visible = true;
                }
                else
                {
                    phLoginForm.Visible = true;
                }
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            using (var ctx = new ForumContext())
            {
                var userStore = new UserStore<User>(ctx);
                var userManager = new UserManager<User>(userStore);
                var user = userManager.Find(txtUserName.Text, txtPassword.Text);

                if (user != null)
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                    Response.Redirect("/Account/Login.aspx");
                }
                else
                {
                    litStatusText.Text = "Invalid username or password.";
                    phLoginStatus.Visible = true;
                }
            }
        }
    }
}