
using E_Commerce.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce.Admin
{
    public partial class AddNewProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
            }
        }

        private void GetCategories()
        {
            DrinkCart d = new DrinkCart();
            DataTable dt = d.GetCategories();
            if (dt.Rows.Count > 0)
            {
                DropCategory.Items.Insert(0, new ListItem("CategoryName", "CategoryID"));

                DropCategory.DataTextField = "CategoryName";
                DropCategory.DataValueField = "CategoryID";
                DropCategory.DataSource = dt;
                DropCategory.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (brwProductImage.PostedFile != null)
            {
                SaveProductPhoto();

                DrinkCart d = new DrinkCart()
                {
                    ProductName = txtProductName.Text,
                    ProductImage = "~/Assets/ProductImages/" + brwProductImage.FileName,
                    ProductPrice = txtProductPrice.Text,
                    ProductDescription = txtProductDescription.Text,
                    CategoryID = Convert.ToInt32(DropCategory.SelectedValue)
                };
                d.AddNewProduct();
                //Alert.Show("Record Saved Successfully");
                //ClearText();
            }
            else
            {

            }
        }

        private void SaveProductPhoto()
        {
            if (brwProductImage != null)
            {
                string filename = brwProductImage.PostedFile.FileName.ToString();
                string fileExt = System.IO.Path.GetExtension(brwProductImage.FileName);

                if (filename.Length > 96 || fileExt != ".jpeg" || fileExt != ".jpp" || fileExt != ".png" || brwProductImage.PostedFile.ContentLength > 400000)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Message here');", true);
                }
                //else if()
                else
                {
                    brwProductImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + filename));
                }
            }
            else
            {

            }
        }
    }
}