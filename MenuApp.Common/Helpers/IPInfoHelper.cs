using System;
using System.IO;
using System.Net;
using System.Text;

namespace MenuApp.Common.Helpers
{
    public class IPInfoHelper
    {
        //http://ip-api.com/docs/api:json
        //http://freegeoip.net/json/ OLD

        private const string url = "http://ip-api.com/json/";
        ///<summary>
        ///IP ADDRESS
        ///</summary>
        public string query;
        public string status;
        public string country;
        public string countryCode;
        public string region;
        public string regionName;
        public string city;
        ///<summary>
        ///ZIP CODE
        ///</summary>
        public string zip;
        ///<summary>
        ///LATITUDE
        ///</summary>
        public long lat;
        ///<summary>
        ///LONGITUDE
        ///</summary>
        public long lon;
        public string timezone;
        ///<summary>
        ///ISP NAME
        ///</summary>
        public string isp;
        ///<summary>
        ///ORGANIZATION NAME
        ///</summary>
        public string org;
        ///<summary>
        ///AS NUMBER / NAME
        ///</summary>
        public string ass;

        //RESULT
        /* 
          {
    "status": "success",
    "country": "COUNTRY",
    "countryCode": "COUNTRY CODE",
    "region": "REGION CODE",
    "regionName": "REGION NAME",
    "city": "CITY",
    "zip": "ZIP CODE",
    "lat": LATITUDE,
    "lon": LONGITUDE,
    "timezone": "TIME ZONE",
    "isp": "ISP NAME",
    "org": "ORGANIZATION NAME",
    "as": "AS NUMBER / NAME",
    "query": "IP ADDRESS USED FOR QUERY"
}
         */
        public static string CallRestMethod(string ip)
        {
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url+ip);
                webrequest.Method = "GET";
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                Encoding enc = Encoding.GetEncoding("utf-8");
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                string result = string.Empty;
                result = responseStream.ReadToEnd();
                webresponse.Close();
                return result;
            }
            catch
            {
                return null;
            }

        }
    }

}
