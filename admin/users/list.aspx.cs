using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Movies.admin.users
{
    public partial class list : System.Web.UI.Page
    {
        string strcon = @"Data Source=USER-31\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        DataTable dt = new DataTable();
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Data();


            }
            
        }
        public void Load_Data()
        {
            SqlDataAdapter sdt = new SqlDataAdapter("select * from [User]", strcon);

            sdt.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                grid_User_view.Columns[4].Visible = false;
            }

            grid_User_view.DataSource = dt;
            grid_User_view.DataBind();
        }

        protected void grid_User_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_User_view.EditIndex = -1;
            Load_Data();

        }

        protected void grid_User_view_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void grid_User_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)grid_User_view.DataKeys[e.RowIndex].Value;

            cn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("Delete from [User] where id = @id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            Load_Data();

        }

        protected void grid_User_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_User_view.EditIndex = e.NewEditIndex;
            Load_Data();
        }

        protected void grid_User_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grid_User_view.DataKeys[e.RowIndex].Value;

            GridViewRow gr = (GridViewRow)grid_User_view.Rows[e.RowIndex];

            TextBox txtUser = (TextBox)gr.Cells[0].Controls[0];
            TextBox txtPass = (TextBox)gr.Cells[1].Controls[0];

            cn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand($"Update [User] set Username = @Username , Password = @Password" +
                $" where ID=@id", cn);
            cmd.Parameters.AddWithValue("@Username", txtUser);
            cmd.Parameters.AddWithValue("@Password", txtPass);
            cmd.Parameters.AddWithValue("@id", id);


            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            grid_User_view.EditIndex = -1;
            Load_Data();


        }

        protected void grid_User_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_User_view.PageIndex = e.NewPageIndex;
            Load_Data();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/users/add.aspx");
        }
    }
}