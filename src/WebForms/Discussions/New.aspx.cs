//system references 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net.Mime;

namespace OtadForum
{
    public partial class NewDiscussion : Page
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
                txtUsername.Focus();
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;

            }
            con.Close();
        }

        //generating date-time logs for each routine click
        protected void load_hidden_data_Click(object sender, EventArgs e)
        {

            txtTime.Text = DateTime.Now.ToString("HH:mm");
            //txtDay.Text = DateTime.Now.ToString();
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            txtPosted_by.Text = "";


        }
        // logging into database as an Admin to start new discussion
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
                    PanelDiscuss.Visible = true;
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

                Load_Forums_dropdown();

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
        }

        // post and start new discussion
        protected void lnkPost_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                txtDate.Text = DateTime.Now.ToLongDateString();
                txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (txtDiscuss_Topic.Text == "") { lblError.Visible = true; lblError.Text = "Mandatory Field is empty: Discussion Topic"; }
                else if (txtDiscussion.Text == "") { lblError.Visible = true; lblError.Text = "Mandatory Field is empty: Discussion details"; }

                else
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO forum_discussions(forum_name, post_subject, post_content, post_category, post_date, post_time, views, comments, date_log, posted_by)VALUES(@forum_name, @post_subject, @post_content, @post_category, @post_date, @post_time, @views, @comments, @date_log, @posted_by)";
                    cmd.Parameters.AddWithValue("@forum_name", drpForumName.Text);
                    cmd.Parameters.AddWithValue("@post_subject", txtDiscuss_Topic.Text);
                    cmd.Parameters.AddWithValue("@post_content", txtDiscussion.Text);
                    cmd.Parameters.AddWithValue("@post_category", txtDiscuss_Category.Text);
                    cmd.Parameters.AddWithValue("@post_date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@post_time", txtTime.Text);
                    cmd.Parameters.AddWithValue("@date_log", txtDateTime.Text);
                    cmd.Parameters.AddWithValue("@posted_by", txtPosted_by.Text);
                    cmd.Parameters.AddWithValue("@views", "0");
                    cmd.Parameters.AddWithValue("@comments", "0");


                    cmd.ExecuteNonQuery();

                    PanelReport.Visible = true;
                    Label1.Text = "You have successfully started a new discussion";

                    Send_Mail();
                    PanelDiscuss.Visible = false;

                    //txtID2.Text = "";
                    drpForumName.Text = "";
                    txtDiscuss_Topic.Text = "";
                    txtDiscussion.Text = "";
                    txtDiscuss_Category.Text = "";
                    txtDate.Text = "";
                    txtTime.Text = "";

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

        // display panel to start new discussion
        protected void lnkNewDiscussion_Click(object sender, EventArgs e)
        {
            PanelReport.Visible = false;
            PanelDiscuss.Visible = true;
            lblError.Visible = false;
        }

        // send notification mail to admin about new discussion started
        protected void Send_Mail()
        {
            try
            {
                txtBody.Text = " Dear Forum Admin, " + "\r\n" + "\r\n" + "A new discussion has just been started on your forum's portal. Please see details below: " + "\r\n" + "\r\n" + "Date.Time Started: " + txtDateTime.Text + "\r\n" + "Started by: " + txtPosted_by.Text + "\r\n" + "Forum Name: " + drpForumName.Text + "\r\n" + "Forum Topic: " + txtDiscuss_Topic.Text + "\r\n" + "Forum Category: " + txtDiscuss_Category.Text + "\r\n" + "Discussion: " + "\r\n" + txtDiscussion.Text + "\r\n" + "\r\n" + "Thank you. " + "\r\n" + "Forum e-Notification System";

                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();

                //if (txtCc.Text != "") { m.CC.Add(new MailAddress(txtCc.Text, txtCcName.Text)); }
                //else
                //{

                m.From = new MailAddress("mtadese.scripts@gmail.com", "Forums e-Notification");
                m.To.Add(new MailAddress("mtadese.scripts@gmail.com", "Forums Mail"));
                // m.CC.Add(new MailAddress(txtCc.Text, txtCcName.Text));
                //m.BCC.Add(new MailAddress("BCC@yahoo.com", "Display name BCC"));

                //}

                m.Subject = "New Discussion started on " + drpForumName.Text + " Forum";
                m.Body = txtBody.Text;

                //section 5
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("mtadese.scripts@gmail.com", "ta**");
                sc.EnableSsl = true;

                //sc.Port = int.Parse(txtPort.Text);
                //sc.Credentials = new System.Net.NetworkCredential(txtCred1.Text, txtCred2.Text);                    
                //sc.EnableSsl = bool.Parse(txtSSL.Text); // runtime encrypt the SMTP communications using SSL
                sc.Send(m);

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
        }

        // load list of available forums
        protected void Load_Forums_dropdown()
        {
            try
            {
                con.Open();
                drpForumName.Items.Clear();
                drpForumName.Items.Add("");

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from forums";

                adap = new MySqlDataAdapter(cmd);
                ds1 = new DataSet();
                adap.Fill(ds1, "forum");

                DataTable dt = ds1.Tables[0];

                foreach (DataRow dr1 in dt.Rows) { drpForumName.Items.Add(dr1[1].ToString()); }

                dr = cmd.ExecuteReader();

            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + err.Message;
            }
            con.Close();
        }


    }
}