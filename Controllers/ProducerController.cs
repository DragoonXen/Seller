using System.Data;
using System.Linq;
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
        public ActionResult Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        //
        // GET: /Producer/Edit/5
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(int id)
        {
            Producer producer = db.Producers.Find(id);
            return View(producer);
        }

        //
        // POST: /Producer/Edit/5

        [HttpPost]
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator, Helper.Roles.TrustedShop)]
        public ActionResult Edit(Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        //
        // GET: /Producer/Delete/5
        [MultiAuthorize(Helper.Roles.Administrator, Helper.Roles.Moderator)]
        public ActionResult Delete(int id)
        {
            Producer producer = db.Producers.Find(id);
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
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}