using System;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Web;

namespace MenuApp.Common.Helpers
{
    public class FileAzureUploaderHelper
    {
        public static bool UploadPhoto(string fileName, HttpPostedFileBase file)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("StorageConnectionString"));

                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference("menusite");

                // Retrieve reference to a blob named "myblob".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.UploadFromStream(file.InputStream);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}