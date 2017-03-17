using System;
using System.Web;
using System.Web.Mvc;

namespace MenuApp.Common.Attributes
{
    public class Authorize : AuthorizeAttribute
    {
        public string Role { get; set; }

        private string AuthorizeUser(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext != null)
            {
                var context = filterContext.RequestContext.HttpContext;

                return (string)context.Session["RoleName"];
            }
            throw new ArgumentException("filterContext");
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentException("filterContext");

            var role = AuthorizeUser(filterContext);
            if (Role == null)
            {
                // insert positive outcome from role check, ie let the action continue
            }
            else
            {
                  throw new HttpException(403, "Bad Request");
            }
        }
    }
}



