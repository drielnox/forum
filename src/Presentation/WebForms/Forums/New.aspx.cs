using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Persistence;
using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using drielnox.Forum.Business.Entities;

namespace OtadForum
{
    public partial class NewForum : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        //generating date-time logs for each routine click
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            txtPosted_by.Text = string.Empty;
        }

        // logging into database as an Admin to create a new forum
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ForumContext())
                {
                    var userStore = new UserStore<User>(ctx);
                    var manager = new UserManager<User>(userStore);

                    var user = manager.Find(txtUsername.Text, txtPassword.Text);
                    if (user == null)
                    {
                        txtUsername.Text = string.Empty;
                        txtPassword.Text = string.Empty;

                        throw new ApplicationException("Invalid Login Details! Try Again");
                    }

                    PanelForum.Visible = true;
                    PanelLogin.Visible = false;
                    HideError();

                    txtPosted_by.Text = txtUsername.Text;
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // save new forum account details
        protected void lnkCreateForum_Click(object sender, EventArgs e)
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
                    var forum = new Forum();
                    forum.Name = txtForumName.Text;
                    forum.Administrator = txtForumAdmin.Text;
                    forum.Email = txtForumEmail.Text;
                    forum.CreatedAt = DateTime.UtcNow;
                    forum.CreatedBy = txtUsername.Text;

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

            Send_Mail();
        }

        // display 'Create New Forum' panel and hide other panel(s)
        protected void lnkNewForum_Click(object sender, EventArgs e)
        {
            PanelForum.Visible = true;
            PanelReport.Visible = false;
        }

        // send notification mail to admin about new forum created
        protected void Send_Mail()
        {
            try
            {
                txtBody.Text = " Dear Forum Admin, " + "\r\n" + "\r\n" + "A new forum has just been created on your forum's portal. Please see details below: " + "\r\n" + "\r\n" + "Date.Time Created: " + txtDateTime.Text + "\r\n" + "Created by: " + txtPosted_by.Text + "\r\n" + "Forum Name: " + txtForumName.Text + "\r\n" + "Forum Admin: " + txtForumAdmin.Text + "\r\n" + "Forum Email: " + txtForumEmail.Text + "\r\n" + "\r\n" + "Thank you. " + "\r\n" + "Forum e-Notification System";

                MailMessage m = new MailMessage();
                m.From = new MailAddress("mtadese.scripts@gmail.com", "Forums e-Notification");
                m.To.Add(new MailAddress("mtadese.scripts@gmail.com", "Forums Mail"));
                m.Subject = "New Forum - '" + txtForumName.Text + "' Created";
                m.Body = txtBody.Text;

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("mtadese.scripts@gmail.com", "ta**");
                sc.EnableSsl = true;
                sc.Send(m);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        private void ClearFields()
        {
            txtForumName.Text = string.Empty;
            txtForumAdmin.Text = string.Empty;
            txtForumEmail.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtDateTime.Text = string.Empty;
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