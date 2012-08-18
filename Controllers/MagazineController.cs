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
        // GET: /Magazine/

        public ViewResult Index()
        {
            return View(db.Magazines.ToList());
        }

        //
        // GET: /Magazine/Details/5

        public ViewResult Details(int id)
        {
            Magazine magazine = db.Magazines.Find(id);
            return View(magazine);
        }

        //
        // GET: /Magazine/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Magazine/Create

        [HttpPost]
        public ActionResult Create(Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Magazines.Add(magazine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magazine);
        }

        //
        // GET: /Magazine/Edit/5

        public ActionResult Edit(int id)
        {
            Magazine magazine = db.Magazines.Find(id);
            return View(magazine);
        }

        //
        // POST: /Magazine/Edit/5

        [HttpPost]
        public ActionResult Edit(Magazine magazine)
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
        // GET: /Magazine/Delete/5

        public ActionResult Delete(int id)
        {
            Magazine magazine = db.Magazines.Find(id);
            return View(magazine);
        }

        //
        // POST: /Magazine/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Magazine magazine = db.Magazines.Find(id);
            db.Magazines.Remove(magazine);
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