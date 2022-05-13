using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class AdminController : Controller
    {
        private Entities db = new Entities();
        // GET: Admin


        public ActionResult Index()
        {
            var productsPricesId = db.Price.Select(currentPrices => currentPrices.id_Product).ToList();
            ProductListViewModel model = new ProductListViewModel
            {
                Products = db.Product.Where(product => productsPricesId.Contains(product.id_Product)).OrderBy(Product => Product.id_Product).Select(c =>
                      new ProductPrice()
                      {
                          Image = c.Image,
                          NameProduct = c.NameProduct,
                          PriceValue = c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault().Price1,
                          OldPrice = c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault(old => old.Id_Price != c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault().Id_Price).Price1,
                          Sales = c.Price.OrderByDescending(price => price.Id_Price).FirstOrDefault().Sales,
                          Description = c.Description,
                          id_Product = c.id_Product
                      }),
            };
            return View(model);
        }

        public ActionResult _CreateCharakteristic()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _EditCharakteristic(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            characteristic characteristics = db.characteristic.Find(id);
            if(characteristics == null)
            {
                return HttpNotFound();
            }
            return View(characteristics);
        }

        [HttpPost]
        public ActionResult _EditCharakteristic(characteristic characteristics)
        {
            db.Entry(characteristics).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult _DeleteCharakteristic(int? id)
        {
            characteristic characteristics = db.characteristic.Find(id);
            if (characteristics == null)
            {
                return HttpNotFound();
            }
            return View(characteristics);
        }

        [HttpPost, ActionName("_DeleteCharakteristic")]
        public ActionResult _DeleteCharakteristicCondirm(int? id)
        {
            characteristic characteristics = db.characteristic.Find(id);
            if (characteristics == null)
            {
                return HttpNotFound();
            }
            db.characteristic.Remove(characteristics);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();

            SelectList idtype = new SelectList(db.TypeProduct, "id_Type", "NameType", product.id_Type);
            ViewBag.idType = idtype;

            SelectList idcategory = new SelectList(db.Category, "id_Category", "NameCategory", product.id_Category);
            ViewBag.idCategory = idcategory;

            SelectList idgarant = new SelectList(db.Guarantee, "id_Guarantee", "Name", product.id_Guarantee);
            ViewBag.idGarant = idgarant;

            SelectList idmanufact = new SelectList(db.Manufacturer, "id_Manufacturer", "Name", product.id_Manufacturer);
            ViewBag.idManufact = idmanufact;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product, string Price1)
        {
                product = db.Product.Add(product);
            db.SaveChanges();
            Price priceObj = new Price()
            {
                id_Product = product.id_Product,
                Price1 = decimal.Parse(Price1),
                //Sales
            };
            db.Price.Add(priceObj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
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
            SelectList idtype = new SelectList(db.TypeProduct, "id_Type", "NameType", product.id_Type);
            ViewBag.idType = idtype;

            SelectList idcategory = new SelectList(db.Category, "id_Category", "NameCategory", product.id_Category);
            ViewBag.idCategory = idcategory;

            SelectList idgarant = new SelectList(db.Guarantee, "id_Guarantee", "Name", product.id_Guarantee);
            ViewBag.idGarant = idgarant;

            SelectList idmanufact = new SelectList(db.Manufacturer, "id_Manufacturer", "Name", product.id_Manufacturer);
            ViewBag.idManufact = idmanufact;

            return View(product);
        }

        //Post
        [HttpPost]
        public ActionResult Edit(Product product, string Price1)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            Price priceObj = new Price()
            {
                id_Product = product.id_Product,
                Price1 = decimal.Parse(Price1),
                //Sales
            };
            db.Price.Add(priceObj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Product product = db.Product.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Product product = db.Product.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}