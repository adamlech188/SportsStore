﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {

            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange - create a new cart
            CartView target = new CartView();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product.Name, p1.Name  );
            Assert.AreEqual(results[1].Product.Name, p2.Name);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {

            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange - create a new cart
            CartView target = new CartView();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 11);
            CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual( 12, results[0].Quantity);
            Assert.AreEqual(1, results[1].Quantity );
        }

        [TestMethod]
        public void Can_Remove_Line()
        {

            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            // Arrange - create a new cart
            CartView target = new CartView();
            // Arrange - add some products to the cart
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            // Act
            target.RemoveLine(p2);

            // Assert
            Assert.AreEqual(target.Lines.Where(c => c.Product.Name == p2.Name).Count(), 0);
            Assert.AreEqual(target.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {

            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create a new cart
            CartView target = new CartView();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            // Assert
            Assert.AreEqual( 450M, result);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {

            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create a new cart
            CartView target = new CartView();

            // Arrange - add some items
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            // Act - reset the cart
            target.Clear();

            // Assert
            Assert.AreEqual(target.Lines.Count(), 0);
        }

        [TestMethod]
        public void Test_Cart_Serialization() {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create a new cart
            CartView target = new CartView();

            // Arrange - add some items
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            var jsonString = JsonConvert.SerializeObject(target);
            Assert.IsTrue(jsonString.GetType() == typeof(string));

            var cartViewObject = JsonConvert.DeserializeObject<CartView>(jsonString);
            decimal price = cartViewObject.Lines.Where(p => p.Product.Name == "P1").Select(p => p.Product.Price).FirstOrDefault();
            Assert.AreEqual(100M, price);  
      }

    }
}
