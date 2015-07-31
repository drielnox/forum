//system references 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace OtadForum
{
    public partial class View_Discussions : System.Web.UI.Page
    {
        //declaration of variables to be used within the program
        string connectionString, id, a, id1;
        MySqlConnection con;
        MySqlDataAdapter adap;
        DataSet ds1, ds;
        MySqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //link to connection string for the C# application and MySql database (full details in web.config file)
                con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
                con.Open();
                Load_Topics();

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;

            }

            con.Close();
        }

        // display discussion topics on gridview control
        protected void Load_Topics()
        {
            try
            {
                //con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM forum_discussions";
                //cmd.CommandText = "SELECT * FROM forum_discussions where surname like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or firstname like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or customer_id like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or group_status like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or email like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or institution like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') ";

                adap = new MySqlDataAdapter(cmd);
                ds1 = new DataSet();
                adap.Fill(ds1, "forum");

                grdTopics.DataSource = ds1.Tables[0];
                grdTopics.DataBind();

                lblError.Visible = false;

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }

            //con.Close();
        }

        // save topic-id of selected discussion in textfield for futher referencing in other modules
        protected void Load_topicID_Textfield()
        {
            try
            {
                //con.Open();
                id = grdTopics.SelectedRow.Cells[0].Text;
                txtTopicID.Text = id;

                a = txtTopicID.Text;

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from forum_discussions where post_id = '" + a + "' ";
                dr = cmd.ExecuteReader();
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            //con.Close();
        }

        //generating date-time logs for each routine on this module
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            txtPosted_by.Text = "";

        }

        // show selected discussion's contents referencing the saved topic-id and loading-up the discussion content's module
        protected void grdTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            Load_topicID_Textfield();
            show_textvalue();

            Response.Redirect("discussion.aspx");

            con.Close();
        }

        //showing text value on multiple page
        protected void show_textvalue()
        {           

            id1 = txtTopicID.Text;
            Session["Value"] = id1;

            //copy this syntax to other pages:

            //string id1;   
            //id1 = (string)(Session["Value"]); 
            //lblLogUser.Text = id1;

        }


    }
}