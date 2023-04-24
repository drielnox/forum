using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;

namespace drielnox.Forum.Presetation.WebForms.Discussions
{
    public partial class NewDiscussion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            lblError.Visible = false;

            Load_Forums_dropdown();
            LoadCategories();
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }

        // post and start new discussion
        protected void lnkPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDiscuss_Topic.Text))
                {
                    throw new ApplicationException("Mandatory Field is empty: Discussion Topic");
                }

                if (string.IsNullOrWhiteSpace(txtDiscussion.Text))
                {
                    throw new ApplicationException("Mandatory Field is empty: Discussion details");
                }

                var forumId = int.Parse(drpForumName.SelectedItem.Value);
                var categoryId = int.Parse(ddlCategory.SelectedItem.Value);

                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums.Single(x => x.Identifier == forumId);
                    var category = ctx.Categories.Single(x => x.Identifier == categoryId);

                    forum.AddDiscussion(category, txtDiscuss_Topic.Text, txtDiscussion.Text);

                    ctx.SaveChanges();
                }

                PanelReport.Visible = true;
                Label1.Text = "You have successfully started a new discussion";

                PanelDiscuss.Visible = false;

                drpForumName.ClearSelection();
                txtDiscuss_Topic.Text = string.Empty;
                ddlCategory.ClearSelection();
                txtDiscussion.Text = string.Empty;

                HideError();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        private void HideError()
        {
            lblError.Visible = false;
        }

        // display panel to start new discussion
        protected void lnkNewDiscussion_Click(object sender, EventArgs e)
        {
            PanelReport.Visible = false;
            PanelDiscuss.Visible = true;
            HideError();
        }

        // load list of available forums
        private void Load_Forums_dropdown()
        {
            drpForumName.Items.Clear();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var forums = ctx.Forums.ToList();

                    foreach (var forum in forums)
                    {
                        var item = new ListItem(forum.Name, forum.Identifier.ToString());
                        drpForumName.Items.Add(item);
                    }
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        private void LoadCategories()
        {
            ddlCategory.Items.Clear();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var categories = ctx.Categories.ToList();

                    foreach (var category in categories)
                    {
                        var item = new ListItem(category.Name, category.Identifier.ToString());
                        ddlCategory.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}