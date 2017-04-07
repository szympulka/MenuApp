using System;

namespace MenuWeb.Core.Entities.BigData
{
    public class Logon
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string IP { get; set; }
        public string CountryCode { get; set; }
        public string CuntryName { get; set; }
        public long Latitude { get; set; }
        public long LongLatitude { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string TimeZone { get; set; }
        public string ZipCode { get; set; }
        public DateTime FullDate { get; set; }
        public string Time { get; set; }
        public string Browser { get; set; }
    }
}
