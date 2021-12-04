using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Moq;

namespace TestPrj
{
    [TestClass]
    public class HomeControllerTests
    {
        //[Theory]                              //не используется в стандартном наборе?
        //[ClassData(typeof(ProductTestData))]] //не используется в стандартном наборе?
        public void IndexActionModelIsComplete(Product[] products)
        {
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            //Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Утверждение
            Assert.AreEqual(
                  controller.Repository.Products //проверяемое
                , model                          //фактическое
                , "Desc"                         //строка (в данном случае "Описание")
                , Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price) //настроечный объект
            );
        }

        [TestMethod]
        public void RepositoryPropertyCallOnce()
        {
            //Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(new[] { new Product { Name = "P1", Price = 500M } });
            var controller = new HomeController { Repository = mock.Object };

            //Действие
            var result = controller.Index();

            //Утверждение
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }

    #region OldTestClass //перенести в другой класс
    //[TestClass]
    //public class HomeControllerTests002
    //{
    //    class ModelCompleteFakeRepository: IRepository
    //    {
    //        public IEnumerable<Product> Products { get; } = new Product[]
    //        {
    //             new Product{Name="P1", Price=275M  }
    //            ,new Product{Name="P2", Price=4.5M }
    //            ,new Product{Name="P3", Price=100.5M }
    //            ,new Product{Name="P4", Price=150.5M }
    //            ,new Product{Name="P5", Price=90.5M }
    //            ,new Product{Name="P6", Price=48.5M }
    //            ,new Product{Name="P7", Price=48.5M }
    //            ,new Product{Name="P8", Price=48.5M }
    //            };

    //        public void AddProduct(Product p)
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }

    //    [TestMethod]
    //    public void IndexActionModelIsComplete()
    //    {
    //        //Организация
    //        var controller = new HomeController();
    //        controller.Repository = new ModelCompleteFakeRepository();

    //        //Действме
    //        var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

    //        //Утверждение
    //        Assert.AreEqual(
    //              controller.Repository.Products
    //            , model
    //            , "Desc", Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price)
    //        );
    //    }

    //    class ModelCopleteFakeRepositoryPricesUnder50 : IRepository
    //    {
    //        public IEnumerable<Product> Products { get; } = new Product[]
    //        {
    //             new Product{Name="P1", Price=275M  }
    //            ,new Product{Name="P2", Price=4.5M }
    //            ,new Product{Name="P3", Price=100.5M }
    //            ,new Product{Name="P4", Price=150.5M }
    //        };

    //        public void AddProduct(Product p)
    //        {
    //            //Empry
    //        }
    //    }

    //    [TestMethod]
    //    public void IndexActionsModelIsCompletePriceUnder50()
    //    {
    //        //Организация
    //        var controller = new HomeController();
    //        controller.Repository = new ModelCopleteFakeRepositoryPricesUnder50();

    //        //Действие
    //        var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

    //        //Утверждение
    //        Assert.AreEqual(
    //              controller.Repository.Products
    //            , model
    //            , "Desc", Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price)
    //        );
    //    }
    //}
    #endregion
}

