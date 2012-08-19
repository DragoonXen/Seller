using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Seller.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Object profile = null;
            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                profile = membershipUser.ProviderUserKey;
            }
            return View(profile);
        }
    }
}