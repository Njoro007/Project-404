
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
                AddSubmitEvent();

                if (Request.QueryString["alert"] == "success")
                {
                    Response.Write("<script>alert('Data saved successfully!');</script>");
                }
            }
        }

        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("AdminUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger
            {
                ControlID = btnSave.UniqueID
            };
            updatePanel.Triggers.Add(trigger);
        }

        private void GetCategories()
        {
            DrinkCart d = new DrinkCart();
            DataTable dt = d.GetCategories();
            if (dt.Rows.Count > 0)
            {
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
                    CategoryID = Convert.ToInt32(DropCategory.SelectedValue),
                    TotalProducts = Convert.ToInt32(txtProductQuantity.Text)
                };
                d.AddNewProduct();
                Response.Write("~/Admin/AddNewProducts.aspx?alert=success");
                //ClearText();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Please upload photo!');", true);
            }
        }

        private void ClearText()
        {
            brwProductImage = null;
            txtProductDescription.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
        }

        private void SaveProductPhoto()
        {
            if (brwProductImage != null)
            {
                string filename = brwProductImage.PostedFile.FileName.ToString();
                string fileExt = System.IO.Path.GetExtension(brwProductImage.FileName);

                if (filename.Length > 96)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('File Name is too long!');", true);
                }
                //else if()
                else if(fileExt != ".jpeg" && fileExt != ".jpp" && fileExt != ".png" && fileExt != ".bmp")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Only jpeg, jpg, png and bmp');", true);
                }
                else if(brwProductImage.PostedFile.ContentLength > 400000)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Image i greater than 4MB!');", true);
                }
                else
                {
                    brwProductImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + filename));
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Success! Saved Image to Server!');", true);

                }
            }
            else
            {

            }
        }
    }
}