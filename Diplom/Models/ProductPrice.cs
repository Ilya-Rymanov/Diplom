using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ProductPrice : Product
    {
        public string PriceValue { get; set; }
        public string OldPrice { get; set; }
        public Nullable<bool> Sales { get; set; }
    }
}