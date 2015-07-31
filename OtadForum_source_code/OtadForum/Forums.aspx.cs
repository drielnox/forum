//system references 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

using MySql.Web.Security;

namespace OtadForum
{
    public partial class Forums : System.Web.UI.Page
    {
        //declaration of variables to be used within the program
        string connectionString, frname, a, id, id1;
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
                Load_Forums();

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;

            }

            con.Close();
        }

        // load all available forums in gridview control
        protected void Load_Forums()
        {
            try
            {
                //con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM forums";
                //cmd.CommandText = "SELECT * FROM forum_discussions where surname like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or firstname like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or customer_id like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or group_status like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or email like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or institution like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') ";

                adap = new MySqlDataAdapter(cmd);
                ds1 = new DataSet();
                adap.Fill(ds1, "forum");

                grdForums.DataSource = ds1.Tables[0];
                grdForums.DataBind();

                lblError.Visible = false;

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }

            //con.Close();
        }

        // display all posted topics under the selected forum
        protected void Load_Topics()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM forum_discussions WHERE forum_name = " + "'" + txtForumName.Text + "'";
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

            con.Close();
        }

        // display forum name in textfield for further referencing on webpage
        protected void Load_ForumName_Textfield()
        {
            try
            {
                //con.Open();
                frname = grdForums.SelectedRow.Cells[1].Text;
                txtForumName.Text = frname;

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            //con.Close();
        }

        // query and display details of selected forum from database 
        protected void Load_Forum_Details()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from forums where forum_name = '" + txtForumName.Text + "' ";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblForum.Text = Convert.ToString(dr[1]) + " Forum";
                    lblAdmin.Text = Convert.ToString(dr[2]);
                    lblEmail.Text = Convert.ToString(dr[3]);
                    lblDate.Text = Convert.ToString(dr[4]);
                    lblTime.Text = Convert.ToString(dr[5]);

                    con.Close();

                }

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
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
            try
            {

                id = grdTopics.SelectedRow.Cells[0].Text;
                txtTopicID.Text = id;

                //a = txtTopicID.Text;

                //MySqlCommand cmd = con.CreateCommand();
                //cmd.CommandText = "Select * from forum_discussions where post_id = '" + a + "' ";
                //dr = cmd.ExecuteReader();
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }

        }

        // save topic-id of selected topic from 'Forums' module to 'Discussions' module to view topic's full discussion 
        protected void show_textvalue()
        {
            //showing text value on multiple page

            id1 = txtTopicID.Text;
            Session["Value"] = id1;

            //copy this syntax to other pages:

            //string id1;   
            //id1 = (string)(Session["Value"]); 
            //lblLogUser.Text = id1;
        }

        // display topic-id of selected topic on 'Discussions' module and open the 'Discussions' module to view full discussion
        protected void grdTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                Load_topicID_Textfield();
                show_textvalue();

                Response.Redirect("discussion.aspx");

                con.Close();
            }

            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
        }

        // display available forums and hide forums' topics module
        protected void lnkForums_Click(object sender, EventArgs e)
        {
            PanelForums.Visible = true;
            PanelDiscuss.Visible = false;

        }


    }
}