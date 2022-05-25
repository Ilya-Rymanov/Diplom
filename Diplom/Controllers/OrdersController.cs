using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class OrdersController : Controller
    {
        Entities1 db = new Entities1();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
    }
}