using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;

namespace OtadForum
{
    public partial class ReadDiscussion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                show_text_values();
                Show_Discussion();
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

        // save topic-id of selected discussion to be referenced from other modules
        protected void show_text_values()
        {
            hidTopicId.Value = (string)Session["Value"];
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

                var discussionId = int.Parse(hidTopicId.Value);

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

                Load_Comments();
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

        // display discussion of selected topics and all comments posted under such discussion
        protected void Show_Discussion()
        {
            try
            {
                var discussionId = int.Parse(hidTopicId.Value);

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

                Load_Comments();
                Update_Views();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // count and displays number of times the discussions have been opened(viewed)
        protected void Update_Views()
        {
            var discussionId = int.Parse(hidTopicId.Value);

            using (var ctx = new ForumContext())
            {
                var discussion = ctx.Forums
                    .SelectMany(x => x.Discussions)
                    .Single(x => x.Identifier == discussionId);

                discussion.ViewCount++;

                ctx.SaveChanges();
            }
        }

        // display by default, all comments posted within a selected discussion
        protected void Load_Comments()
        {
            try
            {
                var discussionId = int.Parse(hidTopicId.Value);

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