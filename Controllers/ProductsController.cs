using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using Seller.DAL;
using Seller.Models;
using Seller.Utils;

namespace Seller.Controllers
{
    public class ProductsController : Controller
    {
        public const string SortOrderPrice = "Price";
        public const string SortOrderPriceDescending = "PriceDesc";
        public const string SortOrderName = "Name";
        public const string SortOrderNameDescending = "NameDesc";

        private readonly DataContext _db = new DataContext();

        public ActionResult Index(int? category, string sortOrder, int? page, int? pageSize, string filter)
        {
            IQueryable<Product> query = from a in _db.Products.Include("Offers").Include("Category").Include("Producer") select a;
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(product => product.Name.ToUpper().Contains(filter.ToUpper()));
            if (!Roles.GetRolesForUser().Any(role => Helper.Roles.AllRoles.Contains(role)))
                query = query.Where(product => product.Approved);
            
            #region Category

            {
                List<Category> categoriesList = _db.Categories.ToList();

                foreach (Category a in categoriesList)
                {
                    if (a.CategoryId == category)
                    {
                        ViewBag.category = a.CategoryId;
                        query = query.Where(product => product.Category.CategoryId == a.CategoryId);
                        break;
                    }
                }

                ViewBag.Categories = new SelectList(categoriesList, "CategoryId", "Name");
            }

            #endregion

            #region Order

            ViewBag.filter = filter;
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

            #endregion

            ViewBag.isUserShop = Session["shopId"] != null;

            int productsPerPage = pageSize ?? 10;
            if (productsPerPage < 1) productsPerPage = int.MaxValue;

            bool isUserShop = Roles.GetRolesForUser().Any(role => Helper.Roles.ShopsRoles.Contains(role));
            ViewBag.isUserShop = isUserShop;

            return View(query.ToPagedList(page ?? 1, productsPerPage));
        }

        public ActionResult BrowseProduct(int id)
        {
            Product product =
                (from a in _db.Products.Include("Offers.Shop").Include("Category").Include("Images").Include("Producer")
                 where a.ProductId == id
                 select a).SingleOrDefault();
            if (Request.RequestType.ToUpper() == "POST")
            {
                return PartialView(product);
            }
            else
            {
                return View(product);
            }
        }
    }
}