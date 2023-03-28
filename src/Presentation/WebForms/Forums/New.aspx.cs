using drielnox.Forum.Business.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace OtadForum
{
    public partial class NewForum : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var admins = new List<User>();

            if (!IsPostBack)
            {
                using (var ctx = new ForumContext())
                {
                    var userStore = new UserStore<User>(ctx);
                    var userManager = new UserManager<User>(userStore);

                    admins = userManager.Users.ToList();
                }

                ddlAdmins.DataSource = admins;
                ddlAdmins.DataBind();
            }

            PanelForum.Visible = true;
        }

        // save new forum account details
        protected void lnkCreateForum_Click(object sender, EventArgs e)
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

                using (var ctx = new ForumContext())
                {
                    var forum = new Forum();
                    forum.Name = txtForumName.Text;
                    forum.Administrator = txtForumAdmin.Text;
                    forum.Email = txtForumEmail.Text;

                    ctx.Forums.Add(forum);

                    ctx.SaveChanges();
                }

                PanelReport.Visible = true;
                Label1.Text = "You have successfully created a new forum";
                PanelForum.Visible = false;

                ClearFields();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // display 'Create New Forum' panel and hide other panel(s)
        protected void lnkNewForum_Click(object sender, EventArgs e)
        {
            PanelForum.Visible = true;
            PanelReport.Visible = false;
        }

        private void ClearFields()
        {
            txtForumName.Text = string.Empty;
            txtForumAdmin.Text = string.Empty;
            txtForumEmail.Text = string.Empty;
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