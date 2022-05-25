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
        private Entities1 db = new Entities1();
        public PartialViewResult Menu()
        {               
            return PartialView();
        }
    }  
}