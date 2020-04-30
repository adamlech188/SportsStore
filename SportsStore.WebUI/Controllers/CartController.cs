using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Service;
using SportsStore.WebUI.ViewModels;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private IOrderProcessor _orderProcessor;

        public CartController(IProductRepository repository, IOrderProcessor orderProcessor)
        {
            _repository = repository;
            _orderProcessor = orderProcessor;
        }

        public ViewResult Index(CartView cart, string returnUrl)
        {
            var viewModel = new CartIndexViewModel {
                Cart = cart, 
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Checkout(CartView cart, ShippingDetailsView shippingDetails) {
            if(cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid) {
                _orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
                return View("Completed");
            }
            else {
                return View(shippingDetails);
            }
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
                RemoveItemToSession(cart, product);
            }
            return RedirectToRoute("Cart", new { returnUrl });
        }
    
        public ViewResult Checkout(CartView cart) {
            return View(new ShippingDetailsView() { Line1 = "1780 Tate Rd",Name = "Adam"});
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


        private void RemoveItemToSession(CartView cart, Product product)
        {
            cart.RemoveLine(product);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }
    }
}