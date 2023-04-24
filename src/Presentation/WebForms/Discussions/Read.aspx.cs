using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;

namespace drielnox.Forum.Presetation.WebForms.Discussions
{
    public partial class ReadDiscussion : Page
    {
        private string _discussionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _discussionId = Request.QueryString.Get("DiscussionId");
                if (string.IsNullOrWhiteSpace(_discussionId))
                {
                    throw new ApplicationException("DiscussionId is null or empty.");
                }

                LoadDiscussion();
                LoadComments();

                if (!IsPostBack)
                {
                    UpdateViews();
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
            lblError.Text = message;
        }

        // display the comment module. required to post comments
        protected void lnkComment_Click(object sender, EventArgs e)
        {
            PanelComment.Visible = true;
        }

        // post user's comment (feedback)
        protected void lnkPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    throw new ApplicationException("No comment to post");
                }

                var discussionId = int.Parse(_discussionId);

                using (var ctx = new ForumContext())
                {
                    var userStore = new UserStore<User>(ctx);
                    var userManager = new UserManager<User>(userStore);

                    var user =  userManager.FindByName(User.Identity.Name);

                    var discussion = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Single(x => x.Identifier == discussionId);

                    discussion.AddComment(txtComment.Text, user.UserName, user.Email);

                    ctx.SaveChanges();
                }

                txtComment.Text = string.Empty;

                PanelComment.Visible = false;
                HideError();

                LoadComments();
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

        /// <summary>
        /// display discussion of selected topics and all comments posted under such discussion
        /// </summary>
        protected void LoadDiscussion()
        {
            try
            {
                var discussionId = int.Parse(_discussionId);

                using (var ctx = new ForumContext())
                {
                    var discussion = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Include(x => x.Forum)
                        .Single(x => x.Identifier == discussionId);

                    litForum.Text = discussion.Forum.Name + " Forum";
                    litTopic.Text = discussion.Subject;
                    litDiscussion.Text = discussion.Content;
                    litBy.Text = discussion.CreatedBy;
                    litAt.Text = discussion.CreatedAt.ToString();
                    litViewCount.Text = discussion.ViewCount.ToString();
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        /// <summary>
        /// count and displays number of times the discussions have been opened(viewed)
        /// </summary>
        protected void UpdateViews()
        {
            var discussionId = int.Parse(_discussionId);

            using (var ctx = new ForumContext())
            {
                var discussion = ctx.Forums
                    .SelectMany(x => x.Discussions)
                    .Single(x => x.Identifier == discussionId);

                discussion.ViewCount++;

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// display by default, all comments posted within a selected discussion
        /// </summary>
        protected void LoadComments()
        {
            try
            {
                var discussionId = int.Parse(_discussionId);

                using (var ctx = new ForumContext())
                {
                    var comments = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Include(x => x.Comments)
                        .Single(x => x.Identifier == discussionId)
                        .Comments;

                    grdComments.DataSource = comments;
                    grdComments.DataBind();
                }

                HideError();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }
    }
}