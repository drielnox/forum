using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;
using System.Data.Entity;

namespace drielnox.Forum.Presetation.WebForms.Forums
{
    public partial class ViewForums : Page
    {
        private string _forumId;

        protected void Page_Load(object sender, EventArgs e)
        {
            HideError();

            try
            {
                _forumId = Request.QueryString.Get("ForumId");
                if (string.IsNullOrWhiteSpace(_forumId))
                {
                    throw new ApplicationException("ForumId is null or empty.");
                }

                LoadForumDetails();
                LoadTopics();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        /// <summary>
        /// display all posted topics under the selected forum
        /// </summary>
        protected void LoadTopics()
        {
            HideError();

            try
            {
                int forumId = int.Parse(_forumId);

                using (var ctx = new ForumContext())
                {
                    var discussions = ctx.Forums
                        .Include(x => x.Discussions)
                        .Single(x => x.Identifier == forumId)
                        .Discussions;
                    grdTopics.DataSource = discussions;
                    grdTopics.DataBind();
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        /// <summary>
        /// query and display details of selected forum from database
        /// </summary>
        protected void LoadForumDetails()
        {
            HideError();

            try
            {
                int forumId = int.Parse(_forumId);

                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums
                        .Single(x => x.Identifier == forumId);
                    litForumName.Text = $"{forum.Name} Forum";
                    litAdmin.Text = forum.Administrator;
                    litEmail.Text = forum.Email;
                    litCreatedAt.Text = forum.CreatedAt.ToString();
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