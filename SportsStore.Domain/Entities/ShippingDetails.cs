﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        public int ShippingDetailsID {get;set;}
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        
        public List<ProductShippingDetails> ProductShippingDetails { get; set; }
    }
}
