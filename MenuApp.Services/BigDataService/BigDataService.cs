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
            if (jsonDetails.status == "success")
            {
                logon.IP = jsonDetails.query;
                logon.City = jsonDetails.city;
                logon.CountryCode = jsonDetails.countryCode;
                logon.CuntryName = jsonDetails.country;
                logon.Latitude = jsonDetails.lat;
                logon.LongLatitude = jsonDetails.lon;
                logon.Region = jsonDetails.region;
                logon.RegionName = jsonDetails.regionName;
                logon.TimeZone = jsonDetails.timezone;
                logon.ZipCode = jsonDetails.zip;
                logon.FullDate = date.LocalDateTime();
                logon.Time = date.LocalDateTime().ToString("HH:mm");
                logon.Browser = browserName;

                _dataContext.Add<Logon>(logon);
                _dataContext.SaveChanges();
            }
        }
    }
}
