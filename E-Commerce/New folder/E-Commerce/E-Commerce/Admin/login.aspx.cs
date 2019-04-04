using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce.Admin
{
    public partial class login : System.Web.UI.Page
    {
        String LoginId, Password;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUname.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginId = WebConfigurationManager.AppSettings["AdminLoginID"];
            Password = WebConfigurationManager.AppSettings["AdminPassword"];

            if (txtUname.Text == LoginId && txtPwd.Text == Password)
            {
                Session["Admin"]="Admin";
                Response.Redirect("~/Admin/AddNewProducts.aspx");
            }
            else
            {
                lblAlert.Text = "Incorrect Password or Username!";
            }
        }
    }
}