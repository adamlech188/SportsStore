using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private SportsStoreContext dbContext = new SportsStoreContext();
        public IEnumerable<Product> Products
        {
            get { return dbContext.Products; }
        }

        public IEnumerable<Product> ProductsByCategory(string category)
        {
            return dbContext.Products.Where( p => p.Category.Name.StartsWith(category));
        }
    }
}
