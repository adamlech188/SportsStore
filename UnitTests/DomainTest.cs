using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain;
using SportsStore.Domain.Entities;
using System.Linq;

namespace UnitTests
{
   [TestClass]
    public class DomainTest
    {
       [TestMethod]
        public void TestDatabase()
        {
            using(var context = new SportsStoreContext()) {
                DbSet<Product> products = context.Products;
                Assert.AreEqual(9, products.Count(), "Number of products wasn't 10");

            }
        }
        [TestMethod]
        public void Test_Categories() {
            using (var context = new SportsStoreContext())
            {
                DbSet<Category> categories = context.Category;
                Assert.AreEqual(3, categories.Count(), "Number of categores wasn't 3");
            }
        }

    }
}
