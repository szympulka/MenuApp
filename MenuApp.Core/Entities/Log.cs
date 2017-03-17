using System;

namespace MenuWeb.Core.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public DateTime DateLog { get; set; }
        public string ErrorPlace { get; set; }
    }
}
