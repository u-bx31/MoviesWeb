using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_Movies
{
    public partial class details : System.Web.UI.Page
    {
        string strcon = @"Data Source=DESKTOP-7MHTBTK\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection cn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        public void Load_data()
        {
            int id = int.Parse(Request.QueryString["id"]);
            cn = new SqlConnection(strcon);
            cmd = new SqlCommand("select * from Movie where id =@id", cn);

            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Title.InnerText = dr["title"].ToString().Trim();
                p_desc.InnerText = dr["Description"].ToString().Trim();
                mv_img.ImageUrl = "/images/" + dr["Image"].ToString();
                Duration.InnerText = dr["Duration"].ToString().Trim();
                date.InnerText = Convert.ToDateTime(dr["ReleaseDate"]).ToString("yyyy-MM-dd");
                rt_form.InnerText = dr["Rating"].ToString().Trim();
                Country.InnerText = dr["Country"].ToString().Trim();

            }
            cn.Close();
        }
    }
}