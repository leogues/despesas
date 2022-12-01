using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despesas.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Console.WriteLine("Teste");
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}
