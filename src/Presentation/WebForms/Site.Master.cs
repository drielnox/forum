using System;
using System.Web.UI;

namespace drielnox.Forum.Presetation.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                pnlUserLogged.Visible = true;
                pnlUserLoggin.Visible = false;
                phUserProfile.Visible = true;

                if (Page.User.IsInRole("Administrator"))
                {
                    phManageForum.Visible = true;
                    phNewForum.Visible = true;
                }
                else
                {
                    phManageForum.Visible = false;
                    phNewForum.Visible = false;
                }
            }
            else
            {
                pnlUserLogged.Visible = false;
                pnlUserLoggin.Visible = true;
                phUserProfile.Visible = false;
            }
        }
    }
}
