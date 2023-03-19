using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.EntityFrameworkCore;
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
            txtTopicID.Text = (string)Session["Value"];
        }

        //generating date-time logs for each routine on this module
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
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
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtDate.Text = DateTime.Now.ToLongDateString();
                txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    throw new ApplicationException("Please enter your name");
                }

                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    throw new ApplicationException("No comment to post");
                }

                using (var ctx = new ForumContext())
                {
                    var discussion = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Single(x => x.Identifier == int.Parse(txtTopicID.Text));

                    discussion.AddComment(txtComment.Text, txtName.Text, txtEmail.Text);

                    ctx.SaveChanges();
                }

                txtComment.Text = string.Empty;
                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDate.Text = string.Empty;
                txtTime.Text = string.Empty;
                txtDateTime.Text = string.Empty;

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
                using (var ctx = new ForumContext())
                {
                    var discussion = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Include(x => x.Forum)
                        .Single(x => x.Identifier == int.Parse(txtTopicID.Text));

                    lblForum.Text = discussion.Forum.Name + " Forum";
                    lblTopic.Text = discussion.Subject;
                    lblDiscussion.Text = discussion.Content;
                    lblDate.Text = discussion.CreatedAt.ToShortDateString();
                    lblTime.Text = discussion.CreatedAt.ToShortTimeString();
                    lblBy.Text = discussion.CreatedBy;
                    txtCommentNo.Text = discussion.CommentsCount.ToString();
                    txtViewNo.Text = discussion.ViewCount.ToString();
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
            using (var ctx = new ForumContext())
            {
                var discussion = ctx.Forums
                    .SelectMany(x => x.Discussions)
                    .Single(x => x.Identifier == int.Parse(txtTopicID.Text));

                discussion.ViewCount++;

                ctx.SaveChanges();
            }
        }

        // display by default, all comments posted within a selected discussion
        protected void Load_Comments()
        {
            try
            {
                using (var ctx = new ForumContext())
                {
                    var comments = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Single(x => x.Identifier == int.Parse(txtTopicID.Text))
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

        // testing 'number of discussion views' syntax
        protected void Button1_Click(object sender, EventArgs e)
        {
            Update_Views();
        }
    }
}