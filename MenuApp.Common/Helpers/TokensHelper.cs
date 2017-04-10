using System;

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
