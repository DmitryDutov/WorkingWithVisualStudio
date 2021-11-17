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
            //�����������
            var p = new Product { Name = "Test", Price = 100M };

            //��������
            p.Name = "New Name";

            //�����������
            Assert.AreEqual("New Name", p.Name);
        }

        [TestMethod]
        public void CanChangeProductPrice()
        {
            //�����������
            var p = new Product { Name = "Test", Price = 100M };

            //��������
            p.Price = 200M;

            //�����������
            Assert.AreEqual(200M, p.Price);
        }
    }

}

