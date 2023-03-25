using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Persistence;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using drielnox.Forum.Business.Entities;

namespace OtadForum
{
    public partial class NewDiscussion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }

        //generating date-time logs for each routine click
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            txtPosted_by.Text = string.Empty;
        }

        // logging into database as an Admin to start new discussion
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ForumContext())
                {
                    var userStore = new UserStore<User>(ctx);
                    var userManager = new UserManager<User>(userStore);

                    var user = userManager.Find(txtUsername.Text, txtPassword.Text);
                    if (user == null)
                    {
                        txtUsername.Text = string.Empty;
                        txtPassword.Text = string.Empty;

                        throw new ApplicationException("Invalid Login Details! Try Again");
                    }
                }

                PanelDiscuss.Visible = true;
                PanelLogin.Visible = false;
                lblError.Visible = false;

                txtPosted_by.Text = txtUsername.Text;

                Load_Forums_dropdown();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // post and start new discussion
        protected void lnkPost_Click(object sender, EventArgs e)
        {
            try
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtDate.Text = DateTime.Now.ToLongDateString();
                txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (string.IsNullOrWhiteSpace(txtDiscuss_Topic.Text))
                {
                    throw new ApplicationException("Mandatory Field is empty: Discussion Topic");
                }

                if (string.IsNullOrWhiteSpace(txtDiscussion.Text))
                {
                    throw new ApplicationException("Mandatory Field is empty: Discussion details");
                }

                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums.Single(x => x.Name == drpForumName.Text);
                    var category = ctx.Categories.Single(x => x.Name == txtDiscuss_Category.Text);

                    forum.AddDiscussion(category, txtDiscuss_Topic.Text, txtDiscussion.Text, txtPosted_by.Text);

                    ctx.SaveChanges();
                }

                PanelReport.Visible = true;
                Label1.Text = "You have successfully started a new discussion";

                Send_Mail();
                PanelDiscuss.Visible = false;

                drpForumName.Text = string.Empty;
                txtDiscuss_Topic.Text = string.Empty;
                txtDiscussion.Text = string.Empty;
                txtDiscuss_Category.Text = string.Empty;
                txtDate.Text = string.Empty;
                txtTime.Text = string.Empty;

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

        // send notification mail to admin about new discussion started
        protected void Send_Mail()
        {
            try
            {
                txtBody.Text = " Dear Forum Admin, " + "\r\n" + "\r\n" + "A new discussion has just been started on your forum's portal. Please see details below: " + "\r\n" + "\r\n" + "Date.Time Started: " + txtDateTime.Text + "\r\n" + "Started by: " + txtPosted_by.Text + "\r\n" + "Forum Name: " + drpForumName.Text + "\r\n" + "Forum Topic: " + txtDiscuss_Topic.Text + "\r\n" + "Forum Category: " + txtDiscuss_Category.Text + "\r\n" + "Discussion: " + "\r\n" + txtDiscussion.Text + "\r\n" + "\r\n" + "Thank you. " + "\r\n" + "Forum e-Notification System";

                MailMessage m = new MailMessage();
                m.From = new MailAddress("mtadese.scripts@gmail.com", "Forums e-Notification");
                m.To.Add(new MailAddress("mtadese.scripts@gmail.com", "Forums Mail"));
                m.Subject = "New Discussion started on " + drpForumName.Text + " Forum";
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

        // load list of available forums
        protected void Load_Forums_dropdown()
        {
            try
            {
                drpForumName.Items.Clear();
                drpForumName.Items.Add("");

                using (var ctx = new ForumContext())
                {
                    var forums = ctx.Forums.ToList();

                    foreach (var forum in forums)
                    {
                        drpForumName.Items.Add(forum.Name);
                    }
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }
    }
}