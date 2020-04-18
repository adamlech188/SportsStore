using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.WebUI.ViewModels
{
    public class CartIndexViewModel
    {
        public CartView Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
