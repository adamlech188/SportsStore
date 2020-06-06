using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavViewComponent : ViewComponent
    {
        private IProductRepository _productRepository; 

        public NavViewComponent (IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        public IViewComponentResult Invoke(bool isHorizontal)
        {
           
            IEnumerable<string> categories = _productRepository.Categories.Select(c => c.Name).Distinct().OrderBy(c => c);
            ViewBag.isHorizontal = isHorizontal;
            return View("Menu",categories);
        }
    }
}