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
            return RedirectToAction("Index", new { returnUrl });
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

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}