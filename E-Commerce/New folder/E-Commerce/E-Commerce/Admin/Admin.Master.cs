using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Admin"]==null)
            {
                Response.Redirect("~/Admin/login.aspx");
            }
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditCategory.aspx");
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewProducts.aspx");
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {

        }

        protected void lblLogo_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}