using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult CatalogPartial()
        {
            return PartialView(db.Category);
        }

        public ActionResult PoductSales()
        {
            return PartialView(db.Product);
        }

        public ActionResult About()
        {
            

            return View(db.Manufacturer.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}