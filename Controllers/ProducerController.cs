using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seller.DAL;
using Seller.Models;
using Seller.Utils;

namespace Seller.Controllers
{
    public class ProducerController : Controller
    {
        private readonly DataContext db = new DataContext();

        //
        // GET: /Producer/
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ViewResult Index()
        {
            return View(db.Producers.ToList());
        }

        //
        // GET: /Producer/Details/5

        public ViewResult Details(int id)
        {
            Producer producer = db.Producers.Find(id);
            return View(producer);
        }

        //
        // GET: /Producer/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Producer/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(HttpPostedFileBase newImage, Producer producer, string submitButtons)
        {
            if (newImage != null)
            {
                String filePath = Guid.NewGuid() + Path.GetExtension(newImage.FileName);

                if (!string.IsNullOrWhiteSpace(producer.LogoPath))
                    System.IO.File.Delete(producer.FullLogoPath);

                producer.LogoPath = filePath;
                ModelState["LogoPath"].Errors.Clear();
                newImage.SaveAs(producer.FullLogoPath);
            }

            if (submitButtons == "Create")
            {
                if (ModelState.IsValid)
                {
                    db.Producers.Add(producer);
                    db.SaveChanges();
                    return RedirectAfterSuccess();
                }
            }

            return View(producer);
        }

        //
        // GET: /Producer/Edit/5
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
                return View("Error");

            return View(producer);
        }

        //
        // POST: /Producer/Edit/5

        [HttpPost]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(HttpPostedFileBase newImage, Producer producer, string submitButtons)
        {
            if (newImage != null)
            {
                String filePath = Guid.NewGuid() + Path.GetExtension(newImage.FileName);

                if (!string.IsNullOrWhiteSpace(producer.LogoPath))
                {
                    string prevValue =
                        db.Producers.Where(item => item.ProducerId == producer.ProducerId).Select(item => item.LogoPath)
                            .SingleOrDefault();
                    if (prevValue != producer.LogoPath)
                        System.IO.File.Delete(producer.FullLogoPath);
                }

                producer.LogoPath = filePath;
                newImage.SaveAs(producer.FullLogoPath);
            }

            if (submitButtons == "Save")
            {
                if (ModelState.IsValid)
                {
                    string prevValue =
                        db.Producers.Where(item => item.ProducerId == producer.ProducerId).Select(item => item.LogoPath)
                            .SingleOrDefault();
                    //remove old image
                    if (prevValue != producer.LogoPath)
                        System.IO.File.Delete(String.Format("{0}Content{1}Images{1}Producers{1}{2}",
                                                            AppDomain.CurrentDomain.BaseDirectory,
                                                            Path.DirectorySeparatorChar, prevValue));
                    db.Entry(producer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectAfterSuccess();
                }
            }
            return View(producer);
        }

        //
        // GET: /Producer/Delete/5
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult Delete(int id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer == null)
                return View("Error");
            ViewBag.CountUsed = db.Products.Count(item => item.ProducerId == id);
            return View(producer);
        }

        //
        // POST: /Producer/Delete/5

        [HttpPost, ActionName("Delete")]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult DeleteConfirmed(int id)
        {
            Producer producer = db.Producers.Find(id);
            db.Producers.Remove(producer);
            db.SaveChanges();
            return RedirectAfterSuccess();
        }

        private ActionResult RedirectAfterSuccess()
        {
            if (Helper.Roles.ModeratorRoles.Any(role => User.IsInRole(role)))
                return RedirectToAction("Index");
            else
                return RedirectToAction("RedirectedBack", "Products");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}