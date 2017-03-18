using System.Web;
using MenuApp.Common.Helpers;
using MenuApp.Core.Entities;
using MenuWeb.Core.Entities.BigData;
using Newtonsoft.Json;


namespace MenuApp.Services.BigDataService
{
    public class BigDataService: IPInfoHelper,IBigDataService
    {
        private IDataContext _dataContext;

        public BigDataService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void IPinfoSave(string browserName)
        {
            var date = new DateTimeHelper();
            var logon = new Logon();
            var jsonDetails = JsonConvert.DeserializeObject<IPInfoHelper>(CallRestMethod(HttpContext.Current.Request.UserHostAddress));
            logon.IP = jsonDetails.IP;
            logon.City = jsonDetails.city;
            logon.CountryCode = jsonDetails.country_code;
            logon.CuntryName = jsonDetails.country_name;
            logon.Latitude = jsonDetails.latitude;
            logon.LongLatitude = jsonDetails.longitude;
            logon.MetroCode = jsonDetails.metrocode;
            logon.RegionName = jsonDetails.region_name;
            logon.TimeZone=jsonDetails.time_zone;
            logon.ZipCode = jsonDetails.zip_code;
            logon.FullDate = date.LocalDateTime();
            logon.Time = date.LocalDateTime().ToString("HH:mm");
            logon.Browser = browserName;

            _dataContext.Add<Logon>(logon);
            _dataContext.SaveChanges();
        }
    }
}
