using System;
using System.IO;
using System.Net;
using System.Text;

namespace MenuApp.Common.Helpers
{
    public class IPInfoHelper
    {
        private const string url = "http://freegeoip.net/json/";
        public string IP;
        public string country_name;
        public string country_code;
        public string region_name;
        public string city;
        public string zip_code;
        public string time_zone;
        public double latitude;
        public float longitude;
        public int metrocode;
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
            catch (Exception ex)
            {
                return null;
            }

        }
    }

}
