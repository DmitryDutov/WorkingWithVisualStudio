using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkingWithVisualStudio.Models;

namespace TestPrj
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CanChangeProductName()
        {
            //Организация
            var p = new Product { Name = "Test", Price = 100M };

            //Действие
            p.Name = "New Name";

            //Утверждение
            Assert.AreEqual("New Name", p.Name);
        }

        [TestMethod]
        public void CanChangeProductPrice()
        {
            //Организация
            var p = new Product { Name = "Test", Price = 100M };

            //Действие
            p.Price = 200M;

            //Утверждение
            Assert.AreEqual(200M, p.Price);
        }
    }

}

