using System.Web;
using MenuApp.Core.Entities;

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
