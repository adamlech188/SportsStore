using SportsStore.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.WebUI.Service
{
    public interface IOrderProcessor
    {
        void ProcessOrder(CartView cart, ShippingDetailsView shippingDetails);
    }
}
