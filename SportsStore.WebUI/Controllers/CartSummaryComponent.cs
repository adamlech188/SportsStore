using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsStore.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.WebUI.Controllers
{
    public class CartSummaryViewComponent : ViewComponent
    { 
        public IViewComponentResult Invoke() {
            ISession session = HttpContext.Session;
            CartView cart = new CartView();
            if(session != null && session.GetString("Cart") != null) {
                cart = JsonConvert.DeserializeObject<CartView>(session.GetString("Cart"));
            }
            return View("CartSummary", cart);
        }
    }
}
