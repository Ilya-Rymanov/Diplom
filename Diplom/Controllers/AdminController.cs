﻿using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                          Description =c.Description,
                          id_Product = c.id_Product
                      }),
            };
            return View(model);
        }
    }
}