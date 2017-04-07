using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Common.Helpers
{
    public class TokensHelper
    {
        public static string GetTokenGuid()
        {
            return Guid.NewGuid().ToString();
    }
    }
}
