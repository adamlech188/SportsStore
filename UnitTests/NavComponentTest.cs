using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;


namespace UnitTests
{
    [TestClass]
    public class NavComponentTest
    {
        [TestMethod]
        public void Selected_Category_Test()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID = 1, Name = "P1", Category = new Category { CategoryId = 1, Name = "Apples"} },
                  new Product { ProductID = 2, Name = "P2", Category = new Category { CategoryId = 2, Name = "Oranges"} }
            });

            NavViewComponent target = new NavViewComponent(mock.Object);
            string categoryToSelect = "Apples";
            target.Invoke(categoryToSelect);
            string result = target.ViewBag.Selected;

            Assert.AreEqual(categoryToSelect, result, "The result is not apples");
        }
    }
}
