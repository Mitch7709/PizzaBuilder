using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBuilder.Data;
using PizzaBuilder.Models;
using PizzaBuilder.Data.Services;

namespace PizzaBuilder.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var pizzaDropdownData = await _service.GetNewPizzaDropDownValues();

            ViewBag.CrustIds = new SelectList(pizzaDropdownData.Crusts);
            ViewBag.ToppingIds = new SelectList(pizzaDropdownData.Toppings);

            return View();
        }
    }
}
