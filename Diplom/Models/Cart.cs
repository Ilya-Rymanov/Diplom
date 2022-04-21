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

        public void AddItemsNew(Product product, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(x=>x.Product.id_Product == product.id_Product);

            line.Quantity++;
            var result = new { qty = line.Quantity, price = line.Price };
        }

        public void DecrementProductNew(Product product, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(x => x.Product.id_Product == product.id_Product);

            if(line.Quantity > 1)
            {
                line.Quantity--;
            }
            else
            {
                line.Quantity = 0;
                lineCollection.Remove(line);
            }

            var result = new { qty = line.Quantity, price = line.Price };
        }

        public void RemoveLine(Product product)
        {
            CartLine line = lineCollection.FirstOrDefault(x => x.Product.id_Product == product.id_Product);
            lineCollection.Remove(line);
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
        public decimal Price { get; set; }
        public decimal Total { get { return Quantity * Price; } }
    }
}