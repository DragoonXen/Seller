using System.Data;
using System.Linq;
using System.Web.Mvc;
using Seller.DAL;
using Seller.Models;

namespace Seller.Controllers
{
    public class ShopController : Controller
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
            Shop shop = db.Shops.Find(id);
            return View(shop);
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
        public ActionResult Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shop);
        }

        //
        // GET: /Shop/Edit/5

        public ActionResult Edit(int id)
        {
            Shop shop = db.Shops.Find(id);
            return View(shop);
        }

        //
        // POST: /Shop/Edit/5

        [HttpPost]
        public ActionResult Edit(Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        //
        // GET: /Shop/Delete/5

        public ActionResult Delete(int id)
        {
            Shop shop = db.Shops.Find(id);
            return View(shop);
        }

        //
        // POST: /Shop/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
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