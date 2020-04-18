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

        public ViewResult Index(string returnUrl)
        {
            var viewModel = new CartIndexViewModel {
                Cart = GetCart(), 
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }


        public RedirectToRouteResult AddToCart(int productId, string returnUrl) {

            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                AddItemToSession(product, 1);
            }
            return RedirectToRoute("Cart", new { returnUrl = returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {

            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToRoute("Cart", new { returnUrl });
        }

        private void AddItemToSession(Product product, int quantity)
        {
            var cartView = GetCart();
            cartView.AddItem(product, quantity);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartView));
        }
        private CartView GetCart()
        {
            var sessionObject = HttpContext.Session.GetString("Cart");
            if (sessionObject != null)
            {
                return JsonConvert.DeserializeObject<CartView>(sessionObject);
            }
            else
            {
                return new CartView();
            }
        }
    }
}