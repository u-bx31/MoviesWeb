using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace TP1_Movies.admin.movies
{
    public partial class add : System.Web.UI.Page
    {
        string strcon = @"Data Source=DESKTOP-7MHTBTK\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection cn ;
        SqlCommand cmd;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    DataBind();

                }

            }
        }

        public void DataBind()
        {
            image.Visible = true;
            int id = int.Parse(Request.QueryString["id"]);
            cn = new SqlConnection(strcon);
            cmd = new SqlCommand("select * from Movie where id =@id", cn);

            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Txt_Title.Text = dr["title"].ToString().Trim();
                Txt_Desciption.Text = dr["Description"].ToString().Trim();
                image.ImageUrl = "/images/"+dr["Image"].ToString();
                Txt_Duration.Text = dr["Duration"].ToString().Trim();
                date_realseDate.Text = Convert.ToDateTime(dr["ReleaseDate"]).ToString("yyyy-MM-dd");
                Txt_Rating.Text = dr["Rating"].ToString().Trim();
                Txt_Country.Text = dr["Country"].ToString().Trim();

            }
            cn.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
                string title = Txt_Title.Text;
                string Description = Txt_Desciption.Text;

                int duration = int.Parse(Txt_Duration.Text);
                float rating = float.Parse(Txt_Rating.Text);
                string Country = Txt_Country.Text;
                cn = new SqlConnection(strcon);

                cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Duration", duration);
                cmd.Parameters.AddWithValue("@Image", fileUpload.FileName.ToString());
                cmd.Parameters.AddWithValue("@Releasedate", date_realseDate.Text);
                cmd.Parameters.AddWithValue("@Rating", string.Format("{0:0.0}", rating));
                cmd.Parameters.AddWithValue("@Country", Country);


                if (fileUpload.HasFile)
                {
                    string path = @"\images\";
                    string imgPath = Request.PhysicalApplicationPath;

                    fileUpload.SaveAs(imgPath + path + fileUpload.FileName);
                }


                cn.Open();
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.CommandText = "Update Movie set Title = @Title ,Description = @Description , Duration = @Duration ,Image = @Image ,ReleaseDate = @Releasedate," +
                        "Rating = @Rating , Country =@Country where id = @id";
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    cmd.CommandText = "insert into Movie values(@Title ,@Description ,@Duration, @Image ,@Releasedate ,@Rating ,@Country)";
                    cmd.ExecuteNonQuery();
                    Response.Redirect("/admin/movies/list.aspx");

                }
                cn.Close();
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/movies/list.aspx");
        }
    }
}