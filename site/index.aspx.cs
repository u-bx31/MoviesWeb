using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TP1_Movies
{
    public partial class index : System.Web.UI.Page
    {
        string strcon = @"Data Source=DESKTOP-7MHTBTK\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DataTable dt = new DataTable();
        PagedDataSource pds = new PagedDataSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_data();
                Load_year();

            }
            
        }

        public int PageNum
        {
            get
            {
                if (ViewState["pageNum"] != null)
                    return Convert.ToInt32(ViewState["pageNum"]);
                return 0;
            }
        }

        public void Load_year()
        {
            for (int i = 1900; i < DateTime.Now.Year; i++)
            {
                drpYearFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));
                drpYearTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

        }



        public void Load_data()
        {

            string query = "select * from Movie";
            string where = " where ";
                if (keyword.Text != String.Empty)
                {
                    query += where + "title like '%" + keyword.Text + "%'";
                    where = " and ";
                }

                if (drpYearFrom.SelectedValue != String.Empty)
                {
                    query += where + "ReleaseDate >= '" + drpYearFrom.Text + "'";
                    where = " and ";
                }
                if (drpYearTo.SelectedValue != String.Empty)
                {
                    query += where + "ReleaseDate <= '" + drpYearTo.Text + "'";
                    where = " and ";
                }
                if(ratingFrom.Text != string.Empty)
                {
                    query += where + "Rating >='" + ratingFrom.Text + "'";
                    where = " and ";
                }                
                if(ratingTO.Text != string.Empty)
                {
                    query += where + "Rating <='" + ratingTO.Text + "'";
                    where = " and ";
                }



            if (drpSort.SelectedValue != "")
            {
                query += " order By " + drpSort.SelectedValue;
            }
            
            SqlDataAdapter sdt = new SqlDataAdapter(query, strcon);

            sdt.Fill(dt);
            


            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 12;
            pds.CurrentPageIndex = PageNum;
            

            

            ArrayList pages = new ArrayList();
            for (int i = 0; i <= pds.PageCount - 1; i++)
            {
                pages.Add(i.ToString());
            }

            rpt_pg.DataSource = pages;
            rpt_pg.DataBind();

            lnk_prev.Enabled = !pds.IsFirstPage;
            lnk_prev.Visible = !pds.IsFirstPage;

            lnk_next.Enabled = !pds.IsLastPage;
            lnk_next.Visible = !pds.IsLastPage;


            rpt_mov.DataSource = pds;
            rpt_mov.DataBind();
        }

        protected void drpSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_data();
        }

        protected void btnSearsh_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Load_data();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            keyword.Text = "";
            drpYearFrom.ClearSelection();
            drpYearTo.ClearSelection();
            ratingFrom.Text = "";
            ratingTO.Text = "";
            
        }

        string colorClass = string.Empty;
        protected void rpt_pg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int pageItem = Convert.ToInt32(e.Item.DataItem);
            LinkButton link_paging = e.Item.FindControl("link_paging") as LinkButton;
            link_paging.Text = (pageItem+1).ToString();
            
            if(PageNum == pageItem)
            {
                link_paging.Enabled = true;
                link_paging.CssClass += " active";
            }
            link_paging.CommandArgument = pageItem.ToString();


        }

        protected void link_paging_Click(object sender, CommandEventArgs e)
        {

            ViewState["pageNum"] = Convert.ToInt32(e.CommandArgument);
            Load_data();
        }

        protected void lnk_prev_Click(object sender, EventArgs e)
        {
            
            ViewState["pageNum"] = PageNum-1;
            Load_data();
        }

        protected void lnk_next_Click(object sender, EventArgs e)
        {
            ViewState["pageNum"] = PageNum + 1;
            Load_data();
        }

        protected void rpt_mov_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Panel pnl = e.Item.FindControl("movi_rt") as Panel;

            DataRowView item = e.Item.DataItem as DataRowView;
            float rate = float.Parse(item["Rating"].ToString());
            if (rate > 7)
            {
                colorClass = " green";
            }
            else if(rate < 6)
            {
                colorClass = " red";
            }
            else
            {
                colorClass = " yellow";
            }

            pnl.CssClass += colorClass;
        }
    }
}