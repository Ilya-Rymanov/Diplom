using Diplom.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class CartController : Controller
    {
        private Entities db = new Entities();
        
        public ViewResult Checkout(Cart cart)
        {
            SelectList idcity = new SelectList(db.CityNew, "id_City", "CityName");
            ViewBag.idCity = idcity;
            Orders orders = new Orders();
            return View(orders);
        }
        [HttpPost]
        public ActionResult Checkout(Cart cart, Orders order)
        {
            string userId =  User.Identity.GetUserId();
            order.UserId = userId;
            cart.Order = order;
            cart.Checkout();
            return RedirectToAction("AddOrders", order);
        }

        [HttpPost]
        public decimal GetDelivery(int idCity)
        {
            string userId = User.Identity.GetUserId();
            CityNew city = db.CityNew.FirstOrDefault(currentCity=>currentCity.id_City == idCity);

            decimal delivery = 0;
            if (city != null && city.Price != null)
            {
                delivery = city.Price.Value;
            }
            return delivery;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public string AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Product.FirstOrDefault(p => p.id_Product == productId);

            if (product == null) return "";

            cart.AddItems(product, 1);
            int sumCart = cart.Lines.Sum(x => x.Quantity);

            return sumCart.ToString();
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl)
        {
            Product product = db.Product.FirstOrDefault(p => p.id_Product == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public JsonResult IncrementProduct(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Product.FirstOrDefault(p => p.id_Product == productId);
            cart.AddItemsNew(product, 1);
            return Json(cart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DecrementProduct(Cart cart,int productId)
        {
            Product product = db.Product.FirstOrDefault(p => p.id_Product == productId);
            cart.DecrementProductNew(product, 0);
            return Json(cart, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Summary(Cart cart)
        {
            
            return PartialView(cart);
            
        }
       
        public ViewResult AddOrders()
        {
            return View();
        }
        
     
        
    }
}