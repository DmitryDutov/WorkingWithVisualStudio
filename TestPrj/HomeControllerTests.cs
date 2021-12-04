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
        class ModelCompleteFakeRepository: IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                 new Product{Name="P1", Price=275M  }
                ,new Product{Name="P2", Price=4.5M }
                ,new Product{Name="P3", Price=100.5M }
                ,new Product{Name="P4", Price=150.5M }
                ,new Product{Name="P5", Price=90.5M }
                ,new Product{Name="P6", Price=48.5M }
                ,new Product{Name="P7", Price=48.5M }
                ,new Product{Name="P8", Price=48.5M }
                };

            public void AddProduct(Product p)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void IndexActionModelIsComplete()
        {
            //Организация
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository();

            //Действме
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Утверждение
            Assert.AreEqual(
                controller.Repository.Products, model
                , "Desc", Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price)
                );
        }

        class ModelCopleteFakeRepositoryPricesUnder50 : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                 new Product{Name="P1", Price=275M  }
                ,new Product{Name="P2", Price=4.5M }
                ,new Product{Name="P3", Price=100.5M }
                ,new Product{Name="P4", Price=150.5M }
            };

            public void AddProduct(Product p)
            {
                //Empry
            }
        }

        [TestMethod]
        public void IndexActionsModelIsCompletePriceUnder50()
        {
            //Организация
            var controller = new HomeController();
            controller.Repository = new ModelCopleteFakeRepositoryPricesUnder50();

            //Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Утверждение
            Assert.AreEqual(
                controller.Repository.Products, model
                , "Desc", Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price)
                );
        }
    }
}

