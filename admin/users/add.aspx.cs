using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Movies.admin.users
{
    public partial class add : System.Web.UI.Page
    {
        string strcon = @"Data Source=DESKTOP-7MHTBTK\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection cn;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                DataBind();

            }
        }

        public void DataBind()
        {
            int id = int.Parse(Request.QueryString["id"]);
            cn = new SqlConnection(strcon);
            cmd = new SqlCommand("select * from [User] where id =@id", cn);

            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_user.Text = dr["Username"].ToString().Trim();
                txt_pass.Text = dr["Password"].ToString().Trim();
            }
            cn.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Username = txt_user.Text;
                string Password = txt_pass.Text;
                
                cn = new SqlConnection(strcon);

                cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);


                cn.Open();
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.CommandText = "Update [User] set Username = @Username , Password = @Password" +
                        " where id = @id";
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    cmd.CommandText = "insert into [User](Username,Password) values(@Username ,@Password )";
                    cmd.ExecuteNonQuery();
                    Response.Redirect("/admin/users/list.aspx");

                }
                cn.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}