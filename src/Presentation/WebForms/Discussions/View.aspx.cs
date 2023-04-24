using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;
using Persistence;

namespace drielnox.Forum.Presetation.WebForms.Discussions
{
    public partial class ViewDiscussions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDiscussions();
        }

        /// <summary>
        /// display discussion topics on gridview control
        /// </summary>
        protected void LoadDiscussions()
        {
            HideError();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var discussions = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Include(x => x.Comments)
                        .ToList();

                    grdTopics.DataSource = discussions;
                    grdTopics.DataBind();
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