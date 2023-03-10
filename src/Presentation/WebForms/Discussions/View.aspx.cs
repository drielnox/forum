using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace OtadForum
{
    public partial class ViewDiscussions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Topics();
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }

        // display discussion topics on gridview control
        protected void Load_Topics()
        {
            HideError();

            try
            {
                using (var ctx = new ForumContext())
                {
                    var discussions = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .Include(x => x.Comments)
                        .ToList();

                    grdTopics.DataSource = discussions;
                    grdTopics.DataBind();
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

        // save topic-id of selected discussion in textfield for futher referencing in other modules
        protected void Load_topicID_Textfield()
        {
            try
            {
                txtTopicID.Text = grdTopics.SelectedRow.Cells[0].Text;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
        }

        //generating date-time logs for each routine on this module
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            txtPosted_by.Text = string.Empty;

        }

        // show selected discussion's contents referencing the saved topic-id and loading-up the discussion content's module
        protected void grdTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_topicID_Textfield();
            show_textvalue();

            Response.Redirect("~/Discussions/View.aspx");
        }

        //showing text value on multiple page
        protected void show_textvalue()
        {
            Session["Value"] = txtTopicID.Text;
        }
    }
}