using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ProductControllerTest
    {

        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductID =1 ,  Name = "Football", Price = 25},
                new Product {ProductID =2 , Name = "Surf board", Price = 179},
                new Product {ProductID =3 , Name = "Running", Price = 95},
                new Product {ProductID =4 , Name = "Blah4", Price = 95},
                new Product {ProductID =5 , Name = "Blah5", Price = 95}
            });
            IProductRepository productRepository = mock.Object;
            ProductController controller = new ProductController(productRepository);
            controller.PageSize = 3;
            IEnumerable<Product> result = ((ProductsListViewModel)controller.List(null,2).Model).Products;
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual( "Blah4", prodArray[0].Name);
            Assert.AreEqual("Blah5", prodArray[1].Name);
        }

        [TestMethod]
        public void Can_Filter_Products() {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.ProductsByCategory("Cat1")).Returns(new List<Product>
            {
                new Product {ProductID =1 ,  Name = "P1", Category = new Category{ CategoryId=1, Name= "Cat1"} },
                new Product {ProductID =1 ,  Name = "P4", Category = new Category{ CategoryId=1, Name= "Cat1"} }
               
            });


            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            IEnumerable<Product> result = ((ProductsListViewModel)controller.List("Cat1", 1).Model).Products;
            Product[] prodArray = result.ToArray();
            Assert.AreEqual(2, prodArray.Length, "Lenght of product list is not 2");
            Assert.AreEqual("Cat1", prodArray[0].Category.Name);
            Assert.AreEqual("P1", prodArray[0].Name);
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            HtmlString result = PagingHelpers.PageLinks(null, pagingInfo, pageUrlDelegate);
            string html = @"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>";
            Assert.AreEqual(html, result.ToString());

        }
    }
}