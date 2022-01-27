using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class ShopController : Controller
    {
        private Entities db = new Entities();
        public int pageSize = 24;
        // GET: Shop
        public ActionResult Index(string category, string genre, int page = 1)
        {

            var productsPricesId = db.Price.Select(currentPrices => currentPrices.id_Product).ToList();
            ProductListViewModel model = new ProductListViewModel
            {
                Products = db.Product.Where(product => productsPricesId.Contains(product.id_Product)).Where(b => category == null || b.Category.NameCategory == category).Where(b => genre == null || b.TypeProduct.NameType == genre).OrderBy(Product => Product.id_Product).Skip((page - 1) * pageSize).Take(pageSize).Select(c =>
                      new ProductPrice()
                      {
                          Image = c.Image,
                          NameProduct = c.NameProduct,
                          PriceValue = c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault().Price1,
                          OldPrice = c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault(old => old.Id_Price != c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault().Id_Price).Price1,
                          Sales = c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault().Sales,
                          id_Product = c.id_Product
                      }),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.Product.Count()
                },
                CuurentGen = genre,
                CuurentGen1 = category
            };
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}