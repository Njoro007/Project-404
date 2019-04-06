
using E_Commerce.Modules;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace E_Commerce.Admin
{
    public partial class AddNewProducts : System.Web.UI.Page
    {
        private string blobUrl,filename,fileExt,localpath,folderpath;
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

        private void ClearText()
        {
            brwProductImage = null;
            txtProductDescription.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
            blobUrl = string.Empty;
        }
        private void SaveProductPhoto()
        {
            if (brwProductImage != null)
            {
                filename = brwProductImage.PostedFile.FileName.ToString();
                localpath = Path.GetFullPath(filename);
                fileExt = System.IO.Path.GetExtension(brwProductImage.FileName);
                //string folderPath = Path.GetDirectoryName(brwProductImage.FileName);
                //localpath = Directory.GetCurrentDirectory();
                folderpath = Convert.ToString(@"F:\\Github\\Project-404\\ProductImages\" + filename);

                Response.Write("<script>alert(" + localpath + ");</script>");

                if (filename.Length > 96)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('File Name is too long!');", true);
                }
                else if (fileExt != ".jpeg" && fileExt != ".jpg" && fileExt != ".png" && fileExt != ".bmp")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Only jpeg, jpg, png and bmp');", true);
                }
                else if (brwProductImage.PostedFile.ContentLength > 400000)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Image i greater than 4MB!');", true);
                }
                else
                {
                    UploadToAzure();
                    //brwProductImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + filename));
                }
            }
            else
            {

            }
        }

        private void UploadToAzure()
        {
            string accountname = "acccmt423";

            string accesskey = "4U1uQqqjmvPvMxP98Jp2K7i5p1F8TEQw5FdaHeuhhTDnmlKOceRGV/5xONP6TWoVVV7DGiFfminEg+yHqvOhHQ==";

            try
            {
                StorageCredentials creden = new StorageCredentials(accountname, accesskey);
                CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
                CloudBlobClient client = acc.CreateCloudBlobClient();
                CloudBlobContainer cont = client.GetContainerReference("contcmt423");
                cont.CreateIfNotExists();
                cont.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

                CloudBlockBlob cblob = cont.GetBlockBlobReference(filename);

                using (Stream file = System.IO.File.OpenRead(@"F:\\Github\\Project-404\\ProductImages\" + filename))
                //using (Stream file = new FileInfo(Path(filename)).Directory.FullName)

                {
                    cblob.UploadFromStream(file);
                    blobUrl = cblob.Uri.AbsoluteUri;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Somethong wrong happened while uploading to azure!');", true);
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
                    ProductImage = blobUrl,
                    ProductPrice = txtProductPrice.Text,
                    ProductDescription = txtProductDescription.Text,
                    CategoryID = Convert.ToInt32(DropCategory.SelectedValue),
                    TotalProducts = Convert.ToInt32(txtProductQuantity.Text)
                };
                d.AddNewProduct();
                Response.Write("~/Admin/AddNewProducts.aspx?alert=success");
                ClearText();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Please upload photo!');", true);
                brwProductImage.Focus();
            }
        }
    }
}