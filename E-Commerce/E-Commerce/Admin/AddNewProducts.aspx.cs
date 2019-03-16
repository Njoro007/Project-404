using E_Commerce.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce.Admin
{
    public partial class AddNewProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetCategories();
            }
        }

        private void GetCategories()
        {
            DrinkCart d = new DrinkCart();
            DataTable dt = d.GetCategories();
            if(dt.Rows.Count > 0)
            {
                DropCategory.DataValueField = "CategoryID";
                DropCategory.DataTextField = "CategoryName";
                DropCategory.DataSource = "dt";
                DropCategory.DataBind();
            }
        }
    }
}