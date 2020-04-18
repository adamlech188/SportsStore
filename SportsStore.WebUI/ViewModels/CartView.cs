using SportsStore.Domain.Entities;
using SportsStore.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.WebUI.ViewModels
{
    public class CartView
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {

                lineCollection.Add(new CartLine
                {
                    Product =
                        new ProductView
                        {
                            ProductID = product.ProductID,
                            CategoryId = product.CategoryId,
                            Description = product.Description,
                            Name = product.Name,
                            Price = product.Price
                        },
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity = quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }


    }

    public class CartLine
    {
        public ProductView Product { get; set; }
        public int Quantity { get; set; }
    }
}
