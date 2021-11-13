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
        public IActionResult Index() => View(SimpleRepository.SharedRepsitory.Products.Where(p => p.Price > 50));
    }
}
