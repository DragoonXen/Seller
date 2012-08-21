using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Seller.DAL;
using Seller.Utils;
using log4net;

namespace Seller
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MvcApplication).FullName);
        private static readonly DataContext DBContext = new DataContext();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Products", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            Helper.Roles.CheckRoles();
            Database.SetInitializer(new DataInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Roles.GetRolesForUser().Any(role => Helper.Roles.ShopsRoles.Contains(role)))
            {
                var userGuid = (Guid) Membership.GetUser().ProviderUserKey;
                HttpContext.Current.Session[Helper.ShopId] =
                    DBContext.Shops.Single(shop => shop.AccountGuid == userGuid).
                        ShopId;
                Log.InfoFormat("Shop {0} logged in", userGuid);
            }
            else
            {
                HttpContext.Current.Session[Helper.ShopId] = null;
            }
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            Log.ErrorFormat("Request {0} from host {1} send an error:{2}{3}", context.Request,
                            context.Request.UserHostAddress, Environment.NewLine, context.Server.GetLastError());
            //context.ClearError();
        }
    }
}