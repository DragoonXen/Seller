using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Seller.DAL;
using Seller.Models;
using Seller.Utils;

namespace Seller.Controllers
{
    [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop, Helper.Roles.Shop)]
    public class ProductManagerController : Controller
    {
        private readonly DataContext _db = new DataContext();

        public ActionResult Create()
        {
            ViewBag.CategoryID = PrepareCategorySelectList(_db.Categories.ToList());
            ViewBag.ProducerID = PrepareProducerSelectList(_db.Producers.ToList());
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.CreatedBy = (Guid) Membership.GetUser().ProviderUserKey;
            if (ModelState.IsValid)
            {
                product.Approved = Helper.Roles.TrustedRoles.Any(role => User.IsInRole(role));
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }

            ViewBag.CategoryId = PrepareCategorySelectList(_db.Categories.ToList());
            ViewBag.ProducerId = PrepareProducerSelectList(_db.Producers.ToList());
            return View(product);
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(int id)
        {
            Product product = _db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult Delete(int id)
        {
            Product product = _db.Products.Find(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private SelectList PrepareCategorySelectList(IEnumerable<Category> categoryList)
        {
            return new SelectList(categoryList, "CategoryId", "Name");
        }

        private SelectList PrepareProducerSelectList(IEnumerable<Producer> producerList)
        {
            return new SelectList(producerList, "ProducerId", "Name");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}