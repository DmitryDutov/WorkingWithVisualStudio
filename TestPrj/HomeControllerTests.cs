using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;

namespace TestPrj
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexActionModelIsComplete()
        {
            //Организация
            var controller = new HomeController();

            //Действме
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Утверждение
            Assert.AreEqual(
                SimpleRepository.SharedRepsitory.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price).ToString()
                );
        }
    }
}

