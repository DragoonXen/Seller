using System;
using System.Collections.Generic;
using System.Data;
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
            PrepareSelectLists();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.CreatedBy = (Guid) Membership.GetUser().ProviderUserKey;
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }

            PrepareSelectLists();
            return View(product);
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(int id)
        {
            Product product = _db.Products.Find(id);

            if (product == null)
                return View("Error");

            PrepareSelectLists();
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
                return RedirectToAction("Index", "Products");
            }
            PrepareSelectLists();
            return View(product);
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult Delete(int id)
        {
            Product product =
                _db.Products.Include("Category").Include("Producer").Include("Images").SingleOrDefault(
                    item => item.ProductId == id);

            if (product == null)
                return View("Error");

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            if (product == null)
                return View("Error");

            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult SetApproved(int id, bool approved)
        {
            if (ChangeApprovedState(id, approved))
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public bool SetApproved(FormCollection formCollection, int id, bool approved)
        {
            return ChangeApprovedState(id, approved);
        }

        private bool ChangeApprovedState(int id, bool approved)
        {
            Product product = _db.Products.Find(id);
            if (product == null || product.Approved == approved)
                return false;
            product.Approved = approved;
            _db.SaveChanges();
            return true;
        }


        private void PrepareSelectLists()
        {
            ViewBag.CategoryID = PrepareCategorySelectList(_db.Categories.ToList());
            ViewBag.ProducerID = PrepareProducerSelectList(_db.Producers.ToList());
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