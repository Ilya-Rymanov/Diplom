using Diplom.Models;
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

        //public ActionResult Index()
        //{
        //    var cart = Session["cart"] as List<Cart> ?? new List<Cart>();
        //    if (cart.Count == 0 || Session["cart"] == null)
        //    {
        //        ViewBag.Massage = "Ваша карзина пуста";
        //        return View(cart);
        //    }
        //    decimal total = 0m;
        //    foreach (var item in cart)
        //    {
        //        total += item.Total;
        //    }
        //    ViewBag.GrandTotal = total;
        //    return View(cart);
        //}
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Product.FirstOrDefault(p => p.id_Product == productId);

            if(product != null)
            {
                cart.AddItems(product, 1);
            }
            return RedirectToAction("Index", "Shop");
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
            //int qty = 0;
            //decimal price = 0m;
            //if (Session["cart"] != null)
            //{
            //    var list = (List<CartLine>)Session["cart"];

            //    foreach (var item in list)
            //    {
            //        qty += item.Quantity;
            //        price += item.Quantity * item.Price;
            //    }
            //}
            //else
            //{
            //    cart.Quantity = 0;
            //    cart.Price = 0m;
            //}
            return PartialView(cart);
            //return PartialView(/*"Summary", model*/);
        }
        //public ActionResult AddToCartPartial(int id)
        //{
            //List<CartLine> cart = Session["cart"] as List<CartLine> ?? new List<CartLine>();
            //Cart model = new Cart();
            //using (Entities db = new Entities())
            //{
            //    Product product = db.Product.Find(id);
            //    var productInCart = cart.FirstOrDefault(x => x.Product.id_Product == id);
            //    if(productInCart == null)
            //    {
            //        cart.Add(new Cart()
            //        {
            //            idProduct = product.id_Product,
            //            ProductName = product.NameProduct,
            //            Quantity = 1,
            //            Price = (decimal)product.Price.OrderByDescending(p => p.Id_Price).FirstOrDefault().Price1,
            //        });
            //    }
            //    else
            //    {
            //        productInCart.Quantity++;
            //    }
            //}
            //int qty = 0;
            //decimal price = 0m;
            //foreach(var item in cart)
            //{
            //    qty += item.Quantity;
            //    price += item.Quantity * item.Price;
            //}

            //model.Quantity = qty;
            //model.Price = price;

            //Session["cart"] = cart;
        //}
    }
}