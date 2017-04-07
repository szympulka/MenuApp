using System;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Web;
using MenuApp.Core.Entities;
using Microsoft.WindowsAzure;

namespace MenuApp.Services.AzureService
{
    public class AzureService: BaseService, IAzureService
    {
        public AzureService(IDataContext dataContext): base(dataContext)
        {

        }

        public bool UploadPhoto(string fileName, HttpPostedFileBase file)
        {
            return MenuApp.Common.Helpers.FileAzureUploaderHelper.UploadPhoto(fileName, file);
        }
    }
}
