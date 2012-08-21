using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seller.Utils
{
    public class MultiAuthorizeAttribute : AuthorizeAttribute
    {
        public MultiAuthorizeAttribute(params String[] roles)
        {
            AuthorizedRoles = roles;
        }

        public String[] AuthorizedRoles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return System.Web.Security.Roles.GetRolesForUser().Any(role => Array.IndexOf(AuthorizedRoles, role) != -1);
        }
    }
}