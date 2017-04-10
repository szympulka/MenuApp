using System.Web;

namespace MenuApp.Services.AzureService
{
    public interface IAzureService
    {
        bool UploadPhoto(string fileName, HttpPostedFileBase file);
    }
}
