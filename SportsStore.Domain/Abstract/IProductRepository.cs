using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Products { get; }

        public IEnumerable<Product> ProductsByCategory(string categoery);
    }
}
