using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController: Controller
    {
        public IRepository Repository = SimpleRepository.SharedRepsitory;
        //SimpleRepository Repository = SimpleRepository.SharedRepsitory;
        public IActionResult Index() => View(SimpleRepository.SharedRepsitory.Products.Where(p => p?.Price > 1));

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}

