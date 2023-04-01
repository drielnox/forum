using System;
using System.Web;
using System.Web.UI;

namespace drielnox.Forum.Presetation.WebForms.Account
{
    public partial class SignOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/Default.aspx");
        }
    }
}