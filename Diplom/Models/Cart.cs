using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItems(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.id_Product == product.id_Product).FirstOrDefault(); 

            if(line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.id_Product == product.id_Product);
        }

        public decimal? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price.OrderByDescending(p => p.Id_Price).FirstOrDefault().Price1 * e.Quantity);
        }
         public void Clear()
        {
            lineCollection.Clear();
        }

    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}