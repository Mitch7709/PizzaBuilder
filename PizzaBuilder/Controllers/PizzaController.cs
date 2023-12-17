using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBuilder.Data;
using PizzaBuilder.Models;
using PizzaBuilder.Data.Services;
using PizzaBuilder.Data.ViewModels;

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


        //GET: Pizza/Create
        public async Task<IActionResult> Create()
        {
            var vm = await _service.GetNewPizzaDropDownValues();

            ViewBag.Crusts = new SelectList(vm.Crusts, "Id", "Name");

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPizzaVM pizza)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var vm = await _service.GetNewPizzaDropDownValues();

                ViewBag.Crusts = new SelectList(vm.Crusts, "Id", "Name");

                return View(vm);
            }

            await _service.AddNewPizza(pizza);
            return RedirectToAction(nameof(Index));
        }
    }
}
