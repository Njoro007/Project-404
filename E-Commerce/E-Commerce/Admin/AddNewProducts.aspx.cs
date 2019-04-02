
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
                //string folderPath = Path.GetDirectoryName(brwProductImage.FileName);
                string dirpath = Directory.GetCurrentDirectory();
                string folderpath=Convert.ToString(brwProductImage.PostedFile.FileName);


                if (filename.Length > 96)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('File Name is too long!');", true);
                }
                //else if()
                else if (fileExt != ".jpeg" && fileExt != ".jpp" && fileExt != ".png" && fileExt != ".bmp")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Only jpeg, jpg, png and bmp');", true);
                }
                else if (brwProductImage.PostedFile.ContentLength > 400000)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Image i greater than 4MB!');", true);
                }
                else
                {
                    brwProductImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + filename));
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Success! Saved Image to Server!');", true);
                }


                //Uploading to Azure
                try

                {
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString"));
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    // This call creates a local CloudBlobContainer object, but does not make a network call
                    // to the Azure Storage Service. The container on the service that this object represents may
                    // or may not exist at this point. If it does exist, the properties will not yet have been
                    // popluated on this object.
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference("cmt423");

                    // This makes an actual service call to the Azure Storage service. Unless this call fails,
                    // the container will have been created.
                    blobContainer.CreateIfNotExists();

                    // This also does not make a service call, it only creates a local object.
                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference("cmt423");

                    // This transfers data in the file to the blob on the service.
                    //using (Stream file = File.OpenRead(filename))
                    //{
                        blob.UploadFromFile(folderpath);
                    //}
                        

                    //StorageCredentials creden = new StorageCredentials(accountname, accesskey);

                    //CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);

                    //CloudBlobClient client = acc.CreateCloudBlobClient();

                    //CloudBlobContainer cont = client.GetContainerReference("cmt423");

                    //cont.CreateIfNotExists();

                    //cont.SetPermissions(new BlobContainerPermissions
                    //{
                    //    PublicAccess = BlobContainerPublicAccessType.Blob

                    //});
                    //CloudBlockBlob cblob  = cont.GetBlockBlobReference("cmt423");

                    //using (Stream file = System.IO.File.OpenRead(folderPath))

                    //{

                    //    cblob.UploadFromStream(file);

                    //}

                }
                catch (Exception ex)

                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Failed to save to azure!');", true);

                }

            }
            else
            {

            }
        }



    }
}