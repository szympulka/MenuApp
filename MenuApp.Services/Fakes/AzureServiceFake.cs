using System.Web;
using MenuApp.Services.AzureService;

namespace MenuApp.Services.Fakes
{
    public class AzureServiceFake: IAzureService
    {
        public bool UploadPhoto(string fileName, HttpPostedFileBase file)
        {
            return true;
        }
    }
}
