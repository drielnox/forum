using System;
using System.Linq;
using System.Web.UI;
using Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using drielnox.Forum.Business.Entities;

namespace OtadForum
{
    public partial class ManageForums : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            Load_Forums();
        }

        // logging into database as an Admin to manage available forums
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ForumContext())
                {
                    var userStore = new UserStore<User>(ctx);
                    var userManager = new UserManager<User>(userStore);

                    var user = userManager.Find(txtUsername.Text, txtPassword.Text);
                    if (user != null) 
                    {
                        PanelForums.Visible = true;
                        PanelLogin.Visible = false;
                        lblError.Visible = false;

                        txtPosted_by.Text = txtUsername.Text;
                    }
                    else
                    {
                        txtUsername.Text = string.Empty;
                        txtPassword.Text = string.Empty;

                        throw new ApplicationException("Invalid Login Details! Try Again");
                    }
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
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
                txtForumID.Text = grdForums.SelectedRow.Cells[0].Text;
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
                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums.SingleOrDefault(x => x.Identifier == int.Parse(txtForumID.Text));
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
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtDate.Text = DateTime.Now.ToLongDateString();
                txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

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

                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums.Single(x => x.Identifier == int.Parse(txtForumID.Text));
                    forum.Name = txtForumName.Text;
                    forum.Administrator = txtForumAdmin.Text;
                    forum.Email = txtForumEmail.Text;
                    forum.AmendedAt = DateTime.UtcNow;
                    forum.AmendedBy = txtUsername.Text;

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