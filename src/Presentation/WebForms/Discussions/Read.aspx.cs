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
    public partial class ReadDiscussion : Page
    {
        private MySqlConnection con;
        private MySqlDataAdapter adap;
        private DataSet ds1;
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //link to connection string for the C# application and MySql database (full details in web.config file)
                con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
                con.Open();
                show_text_values();

                Show_Discussion();
                //Load_Comments();

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;

            }
        }

        // save topic-id of selected discussion to be referenced from other modules
        protected void show_text_values()
        {

            //copy this symtax to other pages:

            string id1;
            id1 = (string)Session["Value"];
            txtTopicID.Text = id1;
        }

        //generating date-time logs for each routine on this module
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //txtPosted_by.Text = "";            
        }

        // display the comment module. required to post comments
        protected void lnkComment_Click(object sender, EventArgs e)
        {
            PanelComment.Visible = true;

        }

        // post user's comment (feedback)
        protected void lnkPost_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtDate.Text = DateTime.Now.ToLongDateString();
                txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (txtName.Text == "") { lblError.Visible = true; lblError.Text = "Please enter your name"; }
                else if (txtComment.Text == "") { lblError.Visible = true; lblError.Text = "No comment to post"; }

                else
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO forum_comments(post_id, comment, comment_date, comment_time, date_log, comment_by, email)VALUES(@post_id, @comment, @comment_date, @comment_time, @date_log, @comment_by, @email)";
                    cmd.Parameters.AddWithValue("@post_id", txtTopicID.Text);
                    cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                    cmd.Parameters.AddWithValue("@comment_date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@comment_time", txtTime.Text);
                    cmd.Parameters.AddWithValue("@date_log", txtDateTime.Text);
                    cmd.Parameters.AddWithValue("@comment_by", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    cmd.ExecuteNonQuery();

                    int y = int.Parse(txtCommentNo.Text) + 1;
                    txtCommentNoNew.Text = y.ToString();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE forum_discussions SET comments=@comments WHERE post_id = '" + txtTopicID.Text + "' ;";
                    cmd.Parameters.AddWithValue("@comments", txtCommentNoNew.Text);
                    cmd.ExecuteNonQuery();


                    txtComment.Text = "";
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtDate.Text = "";
                    txtTime.Text = "";
                    txtDateTime.Text = "";

                    PanelComment.Visible = false;
                    lblError.Visible = false;

                    Load_Comments();
                }

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();


        }

        // display discussion of selected topics and all comments posted under such discussion
        protected void Show_Discussion()
        {
            try
            {

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from forum_discussions where post_id = '" + txtTopicID.Text + "' ";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblForum.Text = Convert.ToString(dr[1]) + " Forum";
                    lblTopic.Text = Convert.ToString(dr[2]);
                    lblDiscussion.Text = Convert.ToString(dr[3]);
                    lblDate.Text = Convert.ToString(dr[5]);
                    lblTime.Text = Convert.ToString(dr[6]);
                    lblBy.Text = Convert.ToString(dr[10]);

                    txtCommentNo.Text = Convert.ToString(dr[8]);
                    txtViewNo.Text = Convert.ToString(dr[7]);

                    con.Close();
                    Load_Comments();

                    Update_Views();


                }

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }

        }

        // count and displays number of times the discussions have been opened(viewed)
        protected void Update_Views()
        {
            con.Open();
            int z = int.Parse(txtViewNo.Text) + 1;
            txtViewNoNew.Text = z.ToString();
            cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE forum_discussions SET views=@views WHERE post_id = '" + txtTopicID.Text + "' ;";
            cmd.Parameters.AddWithValue("@views", txtViewNoNew.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // display by default, all comments posted within a selected discussion
        protected void Load_Comments()
        {
            try
            {
                //con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM forum_comments where post_id = '" + txtTopicID.Text + "'  ";
                //cmd.CommandText = "SELECT * FROM forum_discussions where surname like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or firstname like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or customer_id like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or group_status like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or email like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') or institution like " + "'" + txtSearch.Text + "%' and  group_name in ('clients') ";

                adap = new MySqlDataAdapter(cmd);
                ds1 = new DataSet();
                adap.Fill(ds1, "forum");

                grdComments.DataSource = ds1.Tables[0];
                grdComments.DataBind();

                lblError.Visible = false;

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }

            //con.Close();
        }

        // testing 'number of discussion views' syntax
        protected void Button1_Click(object sender, EventArgs e)
        {
            Update_Views();
        }


    }
}