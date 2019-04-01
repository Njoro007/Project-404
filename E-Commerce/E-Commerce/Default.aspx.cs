using E_Commerce.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblCategoryName.Text = "Popular Drinks";
                lblProducts.Text = "Categories";
                GetCategory();
                GetProducts(0); //Get All Products
            }
            lblAvailableStockAlert.Text = string.Empty;
        }

        private void GetCategory()
        {
            DrinkCart k = new DrinkCart();
            dlCategories.DataSource = null;
            dlCategories.DataSource = k.GetCategories();
            dlCategories.DataBind();
        }

        private void GetProducts(int CategoryID)
        {
            DrinkCart p = new DrinkCart
            {
                CategoryID = CategoryID
            };
            dlProducts.DataSource = null;
            dlProducts.DataSource = p.GetAllProducts();
            dlProducts.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }

        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            //GetMyCart();
            lblCategoryName.Text = "My Drinks Shopping Cart.";
            lblProducts.Text = "Checkout.";
            pnlCategories.Visible = false;
            pnlProducts.Visible = false;
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/login.aspx");
        }

        protected void dlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbtnCategory_Click(object sender, EventArgs e)
        {
            lblProducts.Text = "Categories";
            lblCategoryName.Text = "Category Products";

            pnlMyCart.Visible = false;
            pnlProducts.Visible = true;
            int CategoryID = Convert.ToInt16((((LinkButton)sender).CommandArgument));
            GetProducts(CategoryID);
            //HighLightCartProducts();
        }

        protected void lblLogo_Click(object sender, EventArgs e)
        {
            lblProducts.Text = "Categories";
            lblCategoryName.Text = "All Products";

            pnlCategories.Visible = true;
            pnlProducts.Visible = true;
            pnlMyCart.Visible = false;
            pnlCheckOut.Visible = false;
            pnlEmptyCart.Visible = false;
            pnlOrderPlacedSuccessfully.Visible = false;

            GetProducts(0);
            //HighLightCartProducts();
        }
    }
}