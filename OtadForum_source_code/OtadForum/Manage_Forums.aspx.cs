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
    public partial class Manage_Forums : System.Web.UI.Page
    {
        //declaration of variables to be used within the program
        string connectionString, id, a, id1;
        MySqlConnection con;
        MySqlDataAdapter adap;
        DataSet ds1, ds;
        MySqlDataReader dr;
        MySqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //link to connection string for the C# application and MySql database (full details in web.config file)
                con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
                con.Open();
                txtUsername.Focus();

                Load_Forums();
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;

            }
            con.Close();
        }
        // logging into database as an Admin to manage available forums
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * from forum_users where username = '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "' ";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    PanelForums.Visible = true;
                    PanelLogin.Visible = false;
                    lblError.Visible = false;

                    txtPosted_by.Text = txtUsername.Text;
                    con.Close();
                }
                else
                {
                    lblError.Text = "Invalid Login Details! Try Again";
                    lblError.Visible = true;

                    txtUsername.Text = "";
                    txtPassword.Text = "";

                    con.Close();

                }
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
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
                con.Open();
                id = grdForums.SelectedRow.Cells[0].Text;
                txtForumID.Text = id;

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
        }

        // load selected forum details for updating routines
        protected void Load_Forum_Details()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from forums where forum_id = '" + txtForumID.Text + "' ";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtForumName.Text = Convert.ToString(dr[1]);
                    txtForumAdmin.Text = Convert.ToString(dr[2]);
                    txtForumEmail.Text = Convert.ToString(dr[3]);

                    con.Close();
                }
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
        }

        // display forums on webpage if login is granted
        protected void Load_Forums()
        {
            try
            {
                //con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM forums";

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

        // save updated details into selected forum's record
        protected void lnkUpdateForum_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtDate.Text = DateTime.Now.ToLongDateString();
                txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (txtForumName.Text == "") { lblError.Visible = true; lblError.Text = "Please enter Forum Name"; }
                else if (txtForumAdmin.Text == "") { lblError.Visible = true; lblError.Text = "Please enter Forum Administrator's name"; }
                else if (txtForumEmail.Text == "") { lblError.Visible = true; lblError.Text = "Empty field: Forum's Email Address"; }

                else
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE forums SET forum_name=@forum_name, forum_admin=@forum_admin, forum_email=@forum_email, date_amended=@date_amended, time_amended=@time_amended, date_log_amended=@date_log_amended, amended_by=@amended_by WHERE forum_id = '" + txtForumID.Text + "' ;";

                    cmd.Parameters.AddWithValue("@forum_name", txtForumName.Text);
                    cmd.Parameters.AddWithValue("@forum_admin", txtForumAdmin.Text);
                    cmd.Parameters.AddWithValue("@forum_email", txtForumEmail.Text);
                    cmd.Parameters.AddWithValue("@date_amended", txtDate.Text);
                    cmd.Parameters.AddWithValue("@time_amended", txtTime.Text);
                    cmd.Parameters.AddWithValue("@date_log_amended", txtDateTime.Text);
                    cmd.Parameters.AddWithValue("@amended_by", txtUsername.Text);

                    cmd.ExecuteNonQuery();

                    Label1.Text = "You have successfully updated " + txtForumName.Text + " Forum";
                    PanelReport.Visible = true;
                    PanelReport.Focus();

                    lblError.Visible = false;
                }

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
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