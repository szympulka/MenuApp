using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MenuApp.Services.AzureService
{
    public interface IAzureService
    {
        bool UploadPhoto(string fileName, HttpPostedFileBase file);
    }
}
