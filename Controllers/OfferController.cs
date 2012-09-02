using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Seller.DAL;
using Seller.Models;
using Seller.Utils;

namespace Seller.Controllers
{
    [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop, Helper.Roles.Shop)]
    public class OfferController : Controller
    {
        private readonly DataContext _db = new DataContext();

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult Index()
        {
            return
                View(_db.Offers.Include("Shop").Include("Product").OrderBy(offer => offer.ProductId)
                         .ThenBy(offer => offer.Price).ToList());
        }

        public ActionResult Create(int productId, int shopId)
        {
            return View(new Offer
                {
                    ProductId = productId,
                    ShopId = shopId
                });
        }

        [HttpPost]
        public ActionResult Create(Offer offer)
        {
            int curShopId = -1;
            if (Session[Helper.ShopId] != null)
                curShopId = (int)Session[Helper.ShopId];
            if (offer.ShopId == curShopId)
            {
                offer.LastUpdate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _db.Offers.Add(offer);
                    _db.SaveChanges();
                    return RedirectToAction("RedirectedBack", "Products");
                }
                return View(offer);
            }
            return View("Error");
        }


        public ActionResult Edit(int productId, int shopId)
        {
            Offer offer = _db.Offers.Find(productId, shopId);
            if (offer == null)
                offer = new Offer
                            {
                                ProductId = productId,
                                ShopId = shopId
                            };
            return View(offer);
        }

        [HttpPost]
        public ActionResult Edit(Offer offer)
        {
            int curShopId = -1;
            if (Session[Helper.ShopId] != null)
                curShopId = (int) Session[Helper.ShopId];
            if (offer.ShopId == curShopId)
            {
                offer.LastUpdate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _db.Entry(offer).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("RedirectedBack", "Products");
                }
                return View(offer);
            }
            return View("Error");
        }

        public ActionResult Delete(int productId, int shopId)
        {
            Offer removedOffer =
                _db.Offers.Include("Shop").Include("Product").SingleOrDefault(
                    offer => offer.ShopId == shopId && offer.ProductId == productId);
            if (removedOffer == null)
                return View("Error");
            return View(removedOffer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Offer offer)
        {
            int curShopId = -1;
            if (Session[Helper.ShopId] != null)
                curShopId = (int) Session[Helper.ShopId];
            if (Helper.Roles.ModeratorRoles.Any(role => User.IsInRole(role)) || offer.ShopId == curShopId)
            {
                _db.Entry(offer).State = EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("RedirectedBack", "Products");
            }

            return View("Error");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}