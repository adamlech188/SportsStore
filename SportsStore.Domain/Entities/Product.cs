using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
