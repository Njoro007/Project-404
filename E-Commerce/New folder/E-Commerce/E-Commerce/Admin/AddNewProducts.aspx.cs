
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
                SaveProductPhotoAsync();

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

        private async Task SaveProductPhotoAsync()
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
                    await UploadToAzure();
                    //brwProductImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + filename));
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Success! Saved Image to Server!');", true);
                }

            }
            else
            {

            }
        }

        private static async Task UploadToAzure()
        {
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;
            string sourceFile = null;
            string destinationFile = null;

            // Retrieve the connection string for use with the application. The storage connection string is stored
            // in an environment variable on the machine running the application called storageconnectionstring.
            // If the environment variable is created after the application is launched in a console or with Visual
            // Studio, the shell needs to be closed and reloaded to take the environment variable into account.

            //string storageConnectionString = Environment.GetEnvironmentVariable("AzureStorageConnectionString");
            string storageConnectionString = Environment.GetEnvironmentVariable(CloudConfigurationManager.GetSetting("AzureStorageConnectionString"));

            // Parse the connection string and return a reference to the storage account.
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString"));

            // Check whether the connection string can be parsed.
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                try
                {
                    // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    // Create a container called 'quickstartblobs' and append a GUID value to it to make the name unique. 
                    cloudBlobContainer = cloudBlobClient.GetContainerReference("quickstartblobs" + Guid.NewGuid().ToString());
                    await cloudBlobContainer.CreateAsync();
                    Console.WriteLine("Created container '{0}'", cloudBlobContainer.Name);
                    Console.WriteLine();

                    // Set the permissions so the blobs are public. 
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);

                    // Create a file in your local MyDocuments folder to upload to a blob.
                    string localPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string localFileName = "QuickStart_" + Guid.NewGuid().ToString() + ".txt";
                    sourceFile = Path.Combine(localPath, localFileName);
                    // Write text to the file.
                    File.WriteAllText(sourceFile, "Hello, World!");

                    Console.WriteLine("Temp file = {0}", sourceFile);
                    Console.WriteLine("Uploading to Blob storage as blob '{0}'", localFileName);
                    Console.WriteLine();

                    // Get a reference to the blob address, then upload the file to the blob.
                    // Use the value of localFileName for the blob name.
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(localFileName);
                    await cloudBlockBlob.UploadFromFileAsync(sourceFile);

                    // List the blobs in the container.
                    Console.WriteLine("Listing blobs in container.");
                    BlobContinuationToken blobContinuationToken = null;
                    do
                    {
                        var resultSegment = await cloudBlobContainer.ListBlobsSegmentedAsync(null, blobContinuationToken);
                        // Get the value of the continuation token returned by the listing call.
                        blobContinuationToken = resultSegment.ContinuationToken;
                        foreach (IListBlobItem item in resultSegment.Results)
                        {
                            Console.WriteLine(item.Uri);
                        }
                    } while (blobContinuationToken != null); // Loop while the continuation token is not null.
                    Console.WriteLine();

                    // Download the blob to a local file, using the reference created earlier. 
                    // Append the string "_DOWNLOADED" before the .txt extension so that you can see both files in MyDocuments.
                    destinationFile = sourceFile.Replace(".txt", "_DOWNLOADED.txt");
                    Console.WriteLine("Downloading blob to {0}", destinationFile);
                    Console.WriteLine();
                    await cloudBlockBlob.DownloadToFileAsync(destinationFile, FileMode.Create);
                }
                catch (StorageException ex)
                {
                    Console.WriteLine("Error returned from the service: {0}", ex.Message);
                }
                finally
                {
                    Console.WriteLine("Press any key to delete the sample files and example container.");
                    Console.ReadLine();
                    // Clean up resources. This includes the container and the two temp files.
                    Console.WriteLine("Deleting the container and any blobs it contains");
                    if (cloudBlobContainer != null)
                    {
                        await cloudBlobContainer.DeleteIfExistsAsync();
                    }
                    Console.WriteLine("Deleting the local source file and local downloaded files");
                    Console.WriteLine();
                    File.Delete(sourceFile);
                    File.Delete(destinationFile);
                }
            }
            else
            {
                Console.WriteLine(
                    "A connection string has not been defined in the system environment variables. " +
                    "Add a environment variable named 'storageconnectionstring' with your storage " +
                    "connection string as a value.");
            }
        }
    }
}