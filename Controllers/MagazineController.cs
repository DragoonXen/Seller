using System.Data;
using System.Linq;
using System.Web.Mvc;
using Seller.DAL;
using Seller.Models;

namespace Seller.Controllers
{
    public class MagazineController : Controller
    {
        private readonly DataContext db = new DataContext();

        //
        // GET: /Shop/

        public ViewResult Index()
        {
            return View(db.Shops.ToList());
        }

        //
        // GET: /Shop/Details/5

        public ViewResult Details(int id)
        {
            Shop magazine = db.Shops.Find(id);
            return View(magazine);
        }

        //
        // GET: /Shop/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Shop/Create

        [HttpPost]
        public ActionResult Create(Shop magazine)
        {
            if (ModelState.IsValid)
            {
                db.Shops.Add(magazine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magazine);
        }

        //
        // GET: /Shop/Edit/5

        public ActionResult Edit(int id)
        {
            Shop magazine = db.Shops.Find(id);
            return View(magazine);
        }

        //
        // POST: /Shop/Edit/5

        [HttpPost]
        public ActionResult Edit(Shop magazine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magazine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magazine);
        }

        //
        // GET: /Shop/Delete/5

        public ActionResult Delete(int id)
        {
            Shop magazine = db.Shops.Find(id);
            return View(magazine);
        }

        //
        // POST: /Shop/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop magazine = db.Shops.Find(id);
            db.Shops.Remove(magazine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}