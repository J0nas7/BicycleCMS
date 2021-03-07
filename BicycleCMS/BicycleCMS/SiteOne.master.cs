using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Collections;

namespace BicycleCMS
{
    public partial class SiteOne : System.Web.UI.MasterPage
    {
        private ArrayList cats = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            string categorySql = "SELECT CT_Name, Category_Title, Category_ID FROM " + Global.DB.DBprefix + "ContentType " +
                                    "INNER JOIN " + Global.DB.DBprefix + "Category ON " +
                                    Global.DB.DBprefix + "ContentType.CT_ID = " +
                                    Global.DB.DBprefix + "Category.CT_ID " +
                                    "ORDER BY Category_ID ASC";
            MySqlDataAdapter da = Global.DB.dbAdapt(categorySql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MySqlDataReader rdr = Global.DB.dbRead(categorySql);
            while (rdr.Read())
            {
                int categoryID = rdr.GetInt32("Category_ID");
                this.cats.Add(categoryID);
            }
            Global.DB.closeReader();

            leftNavList.DataSource = ds.Tables[0].DefaultView;
            leftNavList.DataBind();
        }

        protected void Category_Bound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var innerDL = e.Item.FindControl("leftNavItems") as DataList;
                if (innerDL != null)
                {
                    string itemsSql = "SELECT Content_Title FROM " + Global.DB.DBprefix + "Content WHERE Category_ID = " + this.cats[0] + " ORDER BY Content_ID ASC";
                    MySqlDataAdapter da2 = Global.DB.dbAdapt(itemsSql);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    innerDL.DataSource = ds2.Tables[0].DefaultView;
                    innerDL.DataBind();
                    this.cats.RemoveAt(0);
                }
            }
        }
    }
}
