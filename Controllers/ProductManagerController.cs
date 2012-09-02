using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
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
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase newImage, Product product, String submitButton)
        {
            switch (submitButton)
            {
                case "Add Picture":
                    AddPicture(newImage, product);
                    break;
                case "Create":
                    if (ModelState.IsValid)
                    {
                        product.EditedBy = product.CreatedBy = (Guid) Membership.GetUser().ProviderUserKey;
                        _db.Products.Add(product);
                        foreach (Image a in product.Images)
                        {
                            a.Product = product;
                            _db.Images.Add(a);
                        }
                        _db.SaveChanges();
                        return RedirectToAction("RedirectedBack", "Products");
                    }
                    break;
                default:
                    RemovePicture(product, submitButton);
                    break;
            }

            PrepareSelectLists();
            return View(product);
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(int id)
        {
            Product product = _db.Products.Include("Images").SingleOrDefault(model => model.ProductId == id);

            if (product == null)
                return View("Error");

            PrepareSelectLists(product.CategoryId, product.ProducerId);
            return View(product);
        }

        [HttpPost]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(HttpPostedFileBase newImage, Product product, String submitButton)
        {
            switch (submitButton)
            {
                case "Add Picture":
                    AddPicture(newImage, product);
                    break;
                case "Save":
                    if (ModelState.IsValid)
                    {
                        product.EditedBy = (Guid) Membership.GetUser().ProviderUserKey;
                        ICollection<Image> newImages = product.Images.ToList();
                        Dictionary<String, Image> oldImages =
                            _db.Images.Where(img => img.ProductId == product.ProductId).ToDictionary(image => image.Path);
                        foreach (Image a in newImages)
                        {
                            if (oldImages.ContainsKey(a.Path))
                            {
                                oldImages.Remove(a.Path);
                                product.Images.Remove(a);
                            }
                            else
                            {
                                a.Product = product;
                                _db.Images.Add(a);
                            }
                        }
                        foreach (Image a in oldImages.Values)
                        {
                            System.IO.File.Delete(a.FullPath);
                            _db.Images.Remove(a);
                        }

                        _db.Entry(product).State = EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("RedirectedBack", "Products");
                    }
                    break;
                default:
                    RemovePicture(product, submitButton);
                    break;
            }

            PrepareSelectLists(product.CategoryId, product.ProducerId);
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
            Product product = _db.Products.Include("Images").SingleOrDefault(item => item.ProductId == id);
            if (product == null)
                return View("Error");

            foreach(Image a in product.Images)
                System.IO.File.Delete(a.FullPath);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("RedirectedBack", "Products");
        }

        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult SetApproved(int id, bool approved)
        {
            if (ChangeApprovedState(id, approved))
            {
                return RedirectToAction("RedirectedBack", "Products");
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

        private static void AddPicture(HttpPostedFileBase newImage, Product product)
        {
            if (newImage != null)
            {
                String filePath = Guid.NewGuid() + Path.GetExtension(newImage.FileName);

                var newImg = new Image
                                 {
                                     ImageId = -1,
                                     Path = filePath
                                 };
                newImage.SaveAs(newImg.FullPath);
                product.Images.Add(newImg);
            }
        }

        private static void RemovePicture(Product product, string submitButton)
        {
            string path = submitButton.Substring(7); //remove "delete:"
            Image removedImage = product.Images.SingleOrDefault(img => img.Path == path);
            if (removedImage != null)
            {
                if (removedImage.ImageId < 1)
                    System.IO.File.Delete(removedImage.FullPath);
                product.Images.Remove(removedImage);
            }
        }

        private void PrepareSelectLists(int selectedCategoryId = -1, int selectedProducerId = -1)
        {
            ViewBag.CategoryId = PrepareCategorySelectList(_db.Categories.ToList(), selectedCategoryId);
            ViewBag.ProducerId = PrepareProducerSelectList(_db.Producers.ToList(), selectedProducerId);
        }

        private SelectList PrepareCategorySelectList(IEnumerable<Category> categoryList, int categoryId)
        {
            return new SelectList(categoryList, "CategoryId", "Name", categoryId);
        }

        private SelectList PrepareProducerSelectList(IEnumerable<Producer> producerList, int poducerId)
        {
            return new SelectList(producerList, "ProducerId", "Name", poducerId);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}