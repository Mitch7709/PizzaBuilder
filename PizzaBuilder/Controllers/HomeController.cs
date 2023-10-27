using Microsoft.AspNetCore.Mvc;
using PizzaBuilder.Data;
using PizzaBuilder.Models;
using System.Diagnostics;

namespace PizzaBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;

        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}