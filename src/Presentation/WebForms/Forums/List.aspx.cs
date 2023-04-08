using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace drielnox.Forum.Presetation.WebForms.Forums
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideError();

            try
            {
                LoadForums();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        /// <summary>
        /// load all available forums in gridview control
        /// </summary>
        protected void LoadForums()
        {
            HideError();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var forums = ctx.Forums.ToList();
                    grdForums.DataSource = forums;
                    grdForums.DataBind();
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }

        private void HideError()
        {
            lblError.Visible = false;
        }
    }
}