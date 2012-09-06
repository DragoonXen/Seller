using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using log4net;

namespace Seller.Controllers
{
    public class LanguageController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (LanguageController).FullName);

        public void ChangeLanguage(string lang)
        {
            try
            {
                var ci = new CultureInfo(lang);
                Session["Culture"] = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
            catch (Exception e)
            {
                Log.Error(e, e);
            }

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}