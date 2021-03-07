using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace BicycleCMS
{
    public partial class CategoryOne : System.Web.UI.Page
    {
        private int itemId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Iid"] != null)
            {
                string itemId = Request.QueryString["Iid"];
                this.itemId = Int32.Parse(itemId);

                string categoryAndContentSQL = "SELECT Category_Title, Category_Description FROM " + Global.DB.DBprefix + "Category " +
                                    "INNER JOIN " + Global.DB.DBprefix + "Content ON " +
                                    Global.DB.DBprefix + "Category.Category_ID = " +
                                    Global.DB.DBprefix + "Content.Category_ID " +
                                    "WHERE "+ Global.DB.DBprefix + "Content.Content_ID = '" + this.itemId+"' " +
                                    "LIMIT 1";

                MySqlDataReader rdr = Global.DB.dbRead(categoryAndContentSQL);
                if (rdr.Read())
                {
                    Headline.Text = rdr.GetString("Category_Title") +" !! :)";
                } else
                {
                    Headline.Text = "Item ID was not found in the database! :(";
                }
                Global.DB.closeReader();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
