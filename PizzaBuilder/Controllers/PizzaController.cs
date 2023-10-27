using Microsoft.AspNetCore.Mvc;
using PizzaBuilder.Data;

namespace PizzaBuilder.Controllers
{
    public class PizzaController : Controller
    {
        private readonly AppDBContext _context;

        public PizzaController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            

            return View();
        }
    }
}
