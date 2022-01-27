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
           
            IEnumerable<string> categoryProducts = db.Product.Select(type => type.Category.NameCategory).Distinct().OrderBy(x => x);//.Join(db.TypeProduct,
               // u => u.id_Type,
                //c => c.id_Type,
                //(u, c) => new
                //{
                 //   id = u.id_Type,
                 //   NameType = c.NameType
                //});
            return PartialView(categoryProducts);
        }
    }  
}