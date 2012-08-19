using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Seller.DAL;
using Seller.Models;

namespace Seller.Controllers
{
    public class ProductsController : Controller
    {
        public const string SortOrderPrice = "Price";
        public const string SortOrderPriceDescending = "PriceDesc";
        public const string SortOrderName = "Name";
        public const string SortOrderNameDescending = "NameDesc";

        private readonly DataContext db = new DataContext();
        //
        // GET: /Home/

        public ActionResult Index(int? category, string sortOrder, int? page, int? pageSize)
        {
            IQueryable<Product> query = from a in db.Products.Include("Offers").Include("Category").Include("Producer")
                                        select a;

            #region Category

            {
                Category productCategory = null;
                List<Category> categoriesList = db.Categories.ToList();

                foreach (Category a in categoriesList)
                {
                    if (a.CategoryId == category)
                    {
                        ViewBag.category = a.CategoryId;
                        productCategory = a;
                        query = query.Where(product => product.Category.CategoryId == a.CategoryId);
                        break;
                    }
                }

                var categories = new List<SelectListItem>
                                     {
                                         new SelectListItem
                                             {
                                                 Selected = productCategory == null,
                                                 Text = "-select any-",
                                                 Value = ""
                                             }
                                     };

                categoriesList.ForEach(cat => categories.Add(new SelectListItem
                                                                 {
                                                                     Selected = productCategory == cat,
                                                                     Text = cat.Name,
                                                                     Value = cat.CategoryId.ToString()
                                                                 }));
                ViewBag.Categories = categories;
            }

            #endregion

            #region Order

            {
                ViewBag.NameOrder = SortOrderName;
                ViewBag.PriceOrder = SortOrderPrice;

                switch (sortOrder)
                {
                    case SortOrderNameDescending:
                        query = query.OrderByDescending(a => a.Name);
                        ViewBag.Order = SortOrderNameDescending;
                        break;
                    case SortOrderName:
                        query = query.OrderBy(a => a.Name);
                        ViewBag.NameOrder = SortOrderNameDescending;
                        ViewBag.Order = SortOrderName;
                        break;
                    case SortOrderPriceDescending:
                        query = query.OrderByDescending(a => a.Offers.Min(offer => offer.Price));
                        ViewBag.Order = SortOrderPriceDescending;
                        break;
                    default:
                        query = query.OrderBy(a => a.Offers.Min(offer => offer.Price));
                        ViewBag.PriceOrder = SortOrderPriceDescending;
                        ViewBag.Order = SortOrderPrice;
                        break;
                }
            }

            #endregion

            int productsPerPage = pageSize ?? 10;
            if (productsPerPage < 1) productsPerPage = int.MaxValue;
            return View(query.ToPagedList(page ?? 1, productsPerPage));
        }

        public ActionResult BrowseProduct(int id)
        {
            Product product =
                (from a in db.Products.Include("Offers.Shop").Include("Category").Include("Images").Include("Producer")
                 where a.ProductId == id
                 select a).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult BrowseProduct(FormCollection formCollection, int id)
        {
            Product product =
                (from a in db.Products.Include("Offers.Shop").Include("Category").Include("Images").Include("Producer")
                 where a.ProductId == id
                 select a).SingleOrDefault();
            if (product == null)
            {
                return Json("");
            }
            var data = new Dictionary<string, object>();
            data["Name"] = product.Name;
            data["Producer"] = product.Producer.Name;
            data["Type"] = product.Category.Name;
            data["Description"] = product.Description ?? "";
            data["Images"] = from img in product.Images select img.Path;
            data["Offers"] = from offer in product.Offers
                             select
                                 new
                                     {
                                         offer.Price,
                                         Logo = offer.Shop.Image,
                                         offer.Shop.Name,
                                         Phone = offer.Shop.Phone ?? "",
                                         Site = offer.Shop.Site ?? "",
                                         offer.Shop.Email,
                                         Description = offer.Shop.Description ?? "",
                                         Adress = offer.Shop.Adress ?? "",
                                         offer.Shop.Exchange,
                                         LastUpdate = offer.LastUpdate.ToShortDateString()
                                     };
            return Json(data);
        }
    }
}