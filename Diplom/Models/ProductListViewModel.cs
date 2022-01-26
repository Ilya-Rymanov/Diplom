using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductPrice> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CuurentGen { get; set; }
        public TypeProduct TypeProducts { get; set; }
    }
}