using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace TP1_Movies
{
    /// <summary>
    /// Summary description for MoviesWBS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MoviesWBS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public DataTable GetMovies()
        {
            string strcn = @"Data Source=DESKTOP-7MHTBTK\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; ;

            DataTable dt = new DataTable("data1");
            SqlConnection cn = new SqlConnection(strcn);
            SqlDataAdapter sdt = new SqlDataAdapter("select * from Movie", cn);
            sdt.Fill(dt);

            //string json = JsonConvert.SerializeObject(dt, Formatting.Indented);

            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //Context.Response.Write(json);


            //List<string> movisesls = new List<string>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    movisesls.Add(dt.Rows[i]["title"].ToString());
            //}


            return dt;
        }

        [WebMethod]
        public DataTable GetMoviesbyid(int idMovie)
        {
            string strcn = @"Data Source=DESKTOP-7MHTBTK\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; ;

            DataTable dt = new DataTable("data1");
            SqlConnection cn = new SqlConnection(strcn);
            SqlDataAdapter sdt = new SqlDataAdapter($"select * from Movie where id ={idMovie}", cn);
            sdt.Fill(dt);

            //string json = JsonConvert.SerializeObject(dt, Formatting.Indented);

            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //Context.Response.Write(json);


            //List<string> movisesls = new List<string>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[i];
            //    movisesls.Add(dt.Rows[i]["title"].ToString());
            //}


            return dt;
        }


        [WebMethod]
        public string add(int a,int b)
        {
            int s = 0;
            s = a + b;

            return s.ToString();
        }
    }
}
