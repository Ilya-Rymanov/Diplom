using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{

    public class NavController : Controller
    {
        private Entities db = new Entities();
        public PartialViewResult Menu()
        {

            IEnumerable<string> categoryProducts = db.Product.Select(cat => cat.TypeProduct.NameType).Distinct().OrderBy(x => x);
            return PartialView(categoryProducts);
        }
    }  
}