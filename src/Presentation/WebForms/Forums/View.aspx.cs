using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace OtadForum
{
    public partial class ViewForums : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideError();

            try
            {
                Load_Forums();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // load all available forums in gridview control
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

        // display all posted topics under the selected forum
        protected void Load_Topics()
        {
            HideError();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var discussions = ctx.Forums
                        .Include(x => x.Discussions)
                        .Single(x => x.Name == txtForumName.Text)
                        .Discussions;
                    grdTopics.DataSource = discussions;
                    grdTopics.DataBind();
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // display forum name in textfield for further referencing on webpage
        protected void Load_ForumName_Textfield()
        {
            HideError();

            try
            {
                txtForumName.Text = grdForums.SelectedRow.Cells[0].Text;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // query and display details of selected forum from database 
        protected void Load_Forum_Details()
        {
            HideError();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var forum = ctx.Forums
                        .Single(x => x.Name == txtForumName.Text);
                    lblForum.Text = $"{forum.Name} Forum";
                    lblAdmin.Text = forum.Administrator;
                    lblEmail.Text = forum.Email;
                    lblDate.Text = forum.CreatedAt.ToShortDateString();
                    lblTime.Text = forum.CreatedAt.ToShortTimeString();
                }
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // display details and available topics of selected forum
        protected void grdForums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ForumName_Textfield();
            Load_Forum_Details();
            Load_Topics();
            PanelDiscuss.Visible = true;
            PanelForums.Visible = false;
        }

        // save topic-id of selected topic into a textbox for further referencing
        protected void Load_topicID_Textfield()
        {
            HideError();

            try
            {
                txtTopicID.Text = grdTopics.SelectedRow.Cells[0].Text;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // save topic-id of selected topic from 'Forums' module to 'Discussions' module to view topic's full discussion 
        protected void show_textvalue()
        {
            Session["Value"] = txtTopicID.Text;
        }

        // display topic-id of selected topic on 'Discussions' module and open the 'Discussions' module to view full discussion
        protected void grdTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideError();

            try
            {
                Load_topicID_Textfield();
                show_textvalue();

                Response.Redirect("~/Discussions/View.aspx");
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        // display available forums and hide forums' topics module
        protected void lnkForums_Click(object sender, EventArgs e)
        {
            PanelForums.Visible = true;
            PanelDiscuss.Visible = false;
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }

        private void HideError()
        {
            lblError.Visible = false;
        }
    }
}