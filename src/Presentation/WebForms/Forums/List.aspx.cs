using drielnox.Forum.Business.Logic;
using System;

namespace drielnox.Forum.Presetation.WebForms.Forums
{
    public partial class List : System.Web.UI.Page
    {
        private readonly ForumManager _forumManager;

        public List()
        {
            _forumManager = new ForumManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadForums();
        }

        /// <summary>
        /// load all available forums in gridview control
        /// </summary>
        protected void LoadForums()
        {
            var forums = _forumManager.ViewForums();
            grdForums.DataSource = forums;
            grdForums.DataBind();
        }

        private void ShowError(string message)
        {
            pnlError.Visible = true;
            litError.Text = message;
        }

        private void HideError()
        {
            pnlError.Visible = false;
        }
    }
}