using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Movies.admin.movies
{
    public partial class list : System.Web.UI.Page
    {

        string strcon = @"Data Source=USER-31\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        DataTable dt = new DataTable();
        SqlDataAdapter sdt;
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.User.Identity.IsAuthenticated)
            {
                if (!IsPostBack)
                {
                    
                    Load_data();
                }
            }
            else
            {
                FormsAuthentication.RedirectFromLoginPage("username",true);
                
            }
        }

        public void Load_data()
        {
            sdt = new SqlDataAdapter("select * from Movie", strcon);

            sdt.Fill(dt);

            //SqlCommandBuilder cb = new SqlCommandBuilder(sdt);

            //sdt.UpdateCommand = cb.GetUpdateCommand(true);
            //sdt.DeleteCommand = cb.GetDeleteCommand(true);

            grid_view.DataSource = dt;
            grid_view.DataBind();

        }

        protected void grid_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_view.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void grid_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grid_view.DataKeys[e.RowIndex].Value;

            GridViewRow gr = (GridViewRow)grid_view.Rows[e.RowIndex];

            TextBox txtTitle = (TextBox)gr.Cells[0].Controls[0];
            TextBox txtDuration = (TextBox)gr.Cells[1].Controls[0];
            TextBox txtCountry = (TextBox)gr.Cells[2].Controls[0];

            cn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand($"Update Movie set Title='{txtTitle.Text}' , Duration ={txtDuration.Text}, Country = '{txtCountry.Text}'" +
                $" where ID={id}",cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            grid_view.EditIndex = -1;
            Load_data();

            //sdt.UpdateCommand.Parameters["@Title"].Value = txtTitle.Text;
            //sdt.UpdateCommand.Parameters["@Duration"].Value = txtDuration.Text;
            //sdt.UpdateCommand.Parameters["@Country"].Value = txtCountry.Text;




        }

        protected void grid_view_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            

        }

        protected void grid_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_view.EditIndex = -1;
            Load_data();
        }

        protected void grid_view_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int id = (int)grid_view.DataKeys[e.RowIndex].Value;

            cn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand($"delete from Movie where id={id}",cn);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            Load_data();

        }

        protected void grid_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_view.PageIndex = e.NewPageIndex;
            Load_data();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("/admin/movies/add.aspx");
        }

    }
}