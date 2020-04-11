using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository _productRepository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public string Index()
        {
            return $"Hello From product! {_productRepository.Products.ElementAt(0).Name}";
        }

        public ViewResult List(int page = 1)
        {
            IEnumerable<Product> products = _productRepository.Products
            .OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize);
            int productCount = _productRepository.Products.Count();
            PagingInfo pageInfo = new PagingInfo {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = productCount
            };
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = products,
                PagegingInfo = pageInfo
            };
            return View(model);
        }
    }
}