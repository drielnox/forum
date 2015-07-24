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
    public partial class New_Forum : System.Web.UI.Page
    {
        string connectionString, id, a, id1;
        MySqlConnection con;
        //MySqlDataAdapter adap;
        //DataSet ds1, ds;
        MySqlDataReader dr;
        MySqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

        protected void load_hidden_data_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            txtDate.Text = DateTime.Now.ToLongDateString();
            txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            txtPosted_by.Text = "";
        }

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
                    PanelForum.Visible = true;
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

        protected void lnkCreateForum_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "INSERT INTO forums(forum_name, forum_admin, forum_email, date_created, time_created, date_log, created_by)VALUES(@forum_name, @forum_admin, @forum_email, @date_created, @time_created, @date_log, @created_by)";
                    cmd.Parameters.AddWithValue("@forum_name", txtForumName.Text);
                    cmd.Parameters.AddWithValue("@forum_admin", txtForumAdmin.Text);
                    cmd.Parameters.AddWithValue("@forum_email", txtForumEmail.Text);
                    cmd.Parameters.AddWithValue("@date_created", txtDate.Text);
                    cmd.Parameters.AddWithValue("@time_created", txtTime.Text);
                    cmd.Parameters.AddWithValue("@date_log", txtDateTime.Text);
                    cmd.Parameters.AddWithValue("@created_by", txtUsername.Text);

                    cmd.ExecuteNonQuery();

                    PanelReport.Visible = true;
                    Label1.Text = "You have successfully created a new forum";

                    Send_Mail();
                    PanelForum.Visible = false;

                    //txtID2.Text = "";
                    txtForumName.Text = "";
                    txtForumAdmin.Text = "";
                    txtForumEmail.Text = "";
                    txtDate.Text = "";
                    txtTime.Text = "";
                    txtDateTime.Text = "";

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

        protected void lnkDiscussions_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forums.aspx");
        }

        protected void lnkNewDiscussion_Click(object sender, EventArgs e)
        {
            PanelForum.Visible = true;
            PanelReport.Visible = false;
        }

        protected void Send_Mail()
        {
            try
            {
                txtBody.Text = " Dear Forum Admin, " + "\r\n" + "\r\n" + "A new forum has just been created on your forum's portal. Please see details below: " + "\r\n" + "\r\n" + "Date.Time Created: " + txtDateTime.Text + "\r\n" + "Created by: " + txtPosted_by.Text + "\r\n" + "Forum Name: " + txtForumName.Text + "\r\n" + "Forum Admin: " + txtForumAdmin.Text + "\r\n" + "Forum Email: " + txtForumEmail.Text + "\r\n" + "\r\n" + "Thank you. " + "\r\n" + "Forum e-Notification System";

                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();

                //if (txtCc.Text != "") { m.CC.Add(new MailAddress(txtCc.Text, txtCcName.Text)); }
                //else
                //{

                m.From = new MailAddress("mtadese@gmail.com", "Forums e-Notification");
                m.To.Add(new MailAddress("mtadese.scripts@gmail.com", "Forums Mail"));
                // m.CC.Add(new MailAddress(txtCc.Text, txtCcName.Text));
                //m.BCC.Add(new MailAddress("BCC@yahoo.com", "Display name BCC"));

                //}

                m.Subject = "New Forum - '" + txtForumName.Text + "' Created";
                m.Body = txtBody.Text;

                //section 5
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("mtadese.scripts@gmail.com", "tadese15");
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
    }
}