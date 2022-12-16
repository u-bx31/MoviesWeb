using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Movies.admin
{
    public partial class login : System.Web.UI.Page
    {
        string strCon = @"Data Source=USER-31\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["error"] != null)
            {
                div_box.Visible = true;
                txt_userError.Text = "User Name Uncorrect!!";
                txt_passError.Text = "Paasword Uncorrect !!";  
            }

            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/admin/movies/list.aspx");
            }
        }
        
        protected void btn_Log_Click(object sender, EventArgs e)
        {
            string username = txtUser1.Text.Trim();
            string Password = txtPass.Text.Trim();
            bool isCokie = chkCookie.Checked;

            DataTable dt = new DataTable();
            SqlDataAdapter sdt = new SqlDataAdapter("select * from [dbo].[User] where username ='" + username+"' and Password='"+Password+"'",strCon);
            sdt.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), isCokie,"admin");
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                if (isCokie)
                {
                    cookie.Expires = ticket.Expiration;
                }
                cookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(cookie);
                ViewState["error"] = false;
                Response.Redirect("/admin/movies/list.aspx", true);
                

            }
            else
            {

                Response.Redirect("login.aspx?error=all", true);

            }
        }
    }
}