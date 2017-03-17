using System.Security.Cryptography;
using System.Text;

namespace MenuApp.Common.Helpers
{
    public class PassHelper
    {
        public static string HashPassword(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            var sha1Data = sha1.ComputeHash(data);
            var encoder = new ASCIIEncoding();
            var hashedpassword = encoder.GetString(sha1Data);
            return hashedpassword;
        }
    }
}