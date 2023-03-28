using drielnox.Forum.Presetation.WebForms.Account;
using System;
using System.Web.UI;

namespace C3_Platform
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated && Page.GetType().BaseType != typeof(Login))
            {
                Response.Redirect("/Account/Login.aspx");
            }
        }
    }
}
