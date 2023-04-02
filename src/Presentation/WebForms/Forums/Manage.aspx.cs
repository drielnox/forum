using System;
using System.Linq;
using System.Web.UI;
using Persistence;

namespace OtadForum
{
    public partial class ManageForums : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            Load_Forums();
        }

        // display available forums on a gridbox control
        protected void grdForums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ForumID_Textfield();
            Load_Forum_Details();
            PanelForums.Visible = false;
            PanelForum.Visible = true;
        }

        // load forum id into textfield for further reviews
        protected void Load_ForumID_Textfield()
        {
            try
            {
                hidForumId.Value = grdForums.SelectedRow.Cells[0].Text;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // load selected forum details for updating routines
        protected void Load_Forum_Details()
        {
            try
            {
                var forumId = int.Parse(hidForumId.Value);

                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums.SingleOrDefault(x => x.Identifier == forumId);
                    if (forum != null)
                    {
                        txtForumName.Text = forum.Name;
                        txtForumAdmin.Text = forum.Administrator;
                        txtForumEmail.Text = forum.Email;
                    }
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // display forums on webpage if login is granted
        protected void Load_Forums()
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

        private void HideError()
        {
            lblError.Visible = false;
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }

        // save updated details into selected forum's record
        protected void lnkUpdateForum_Click(object sender, EventArgs e)
        {
            HideError();

            try
            {
                if (string.IsNullOrWhiteSpace(txtForumName.Text))
                {
                    throw new ApplicationException("Please enter Forum Name");
                }

                if (string.IsNullOrWhiteSpace(txtForumAdmin.Text))
                {
                    throw new ApplicationException("Please enter Forum Administrator's name");
                }

                if (string.IsNullOrWhiteSpace(txtForumEmail.Text))
                {
                    throw new ApplicationException("Empty field: Forum's Email Address");
                }

                var forumId = int.Parse(hidForumId.Value);

                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums.Single(x => x.Identifier == forumId);
                    forum.Name = txtForumName.Text;
                    forum.Administrator = txtForumAdmin.Text;
                    forum.Email = txtForumEmail.Text;

                    ctx.SaveChanges();
                }

                Label1.Text = "You have successfully updated " + txtForumName.Text + " Forum";
                PanelReport.Visible = true;
                PanelReport.Focus();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // display all forums on gridview control and hide other details
        protected void lnkForums_Click(object sender, EventArgs e)
        {
            PanelForums.Visible = true;
            PanelForum.Visible = false;
            PanelReport.Visible = false;
        }
    }
}