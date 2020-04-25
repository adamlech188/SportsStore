using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.ViewModels;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;

        private CartView _cart = null; 
        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(CartView cart, string returnUrl)
        {
            var viewModel = new CartIndexViewModel {
                Cart = cart, 
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }


        public RedirectToRouteResult AddToCart(CartView cart, int productId, string returnUrl) {

            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                AddItemToSession(cart, product, 1);
            }
            return RedirectToRoute("Cart", new { returnUrl = returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(CartView cart, int productId, string returnUrl)
        {

            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToRoute("Cart", new { returnUrl });
        }

        private void AddItemToSession(CartView cart, Product product, int quantity)
        {
            var sessionObject =  HttpContext.Session.GetString("Cart");
            if (sessionObject == null) {
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            var cartView = JsonConvert.DeserializeObject<CartView>(HttpContext.Session.GetString("Cart"));
            cartView.AddItem(product, quantity);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartView));
        }

    }
}