using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class ProductShippingDetails
    {
        public int ProductID { get; set; }
        public int ShippingDetailsID { get; set; }
        public Product Product { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
    }
}
