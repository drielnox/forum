using drielnox.Forum.Business.Entities;
using drielnox.Forum.Business.Logic;
using drielnox.Forum.Business.Logic.DTOs.Requests;
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
        private readonly ForumManager _manager;

        public NewForum()
        {
            _manager = new ForumManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx");
            }

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

        /// <summary>
        /// save new forum account details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCreateForum_Click(object sender, EventArgs e)
        {
            HideError();

            try
            {
                if (string.IsNullOrWhiteSpace(txtForumName.Text))
                {
                    throw new ApplicationException("Please enter Forum Name");
                }

                if (string.IsNullOrWhiteSpace(ddlAdmins.SelectedValue))
                {
                    throw new ApplicationException("Please enter Forum Administrator's name");
                }

                if (string.IsNullOrWhiteSpace(txtForumEmail.Text))
                {
                    throw new ApplicationException("Empty field: Forum's Email Address");
                }

                var request = new CreateForumRequest(txtForumName.Text, ddlAdmins.SelectedItem.Value, txtForumEmail.Text);
                _manager.CreateForum(request);

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

        /// <summary>
        /// display 'Create New Forum' panel and hide other panel(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkNewForum_Click(object sender, EventArgs e)
        {
            PanelForum.Visible = true;
            PanelReport.Visible = false;
        }

        private void ClearFields()
        {
            txtForumName.Text = string.Empty;
            ddlAdmins.ClearSelection();
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