using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBuilder.Data;
using PizzaBuilder.Models;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Services;

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
            var vm = await _service.GetPizzaMenu();

            ViewBag.Crusts = new SelectList(vm.Crusts, "Id", "Name", vm.Crusts.Last().Name);
            ViewBag.Sizes = new SelectList(vm.Size, "Id", "Name");

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePizzaVM pizza)
        {
            if (!ModelState.IsValid)
            {
                var vm = await _service.GetNewPizzaValues();

                ViewBag.Crusts = new SelectList(vm.Crusts, "Id", "Name");
                ViewBag.Sizes = new SelectList(vm.Size, "Id", "Name");

                return View(vm);
            }

            await _service.AddNewPizza(pizza);
            return RedirectToAction(nameof(Orders));
        }

        [HttpGet]
        public async Task<ActionResult> GetTemplateOptions(int templateId)
        {
            var toppList = await _service.GetTemplateOptions(templateId);

            return Json(toppList);
        }

        //GET: Pizza/Orders
        public async Task<IActionResult> Orders()
        {
            var vm = await _service.GetPizzaOrders();

            return View(vm);
        }

        //GET: Pizza/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var pizzaDetails = await _service.GetPizzaById(id);
            if (pizzaDetails == null) return View("NotFound");

            var response = await _service.GetNewPizzaValues();
            ViewBag.Crusts = new SelectList(response.Crusts, "Id", "Name");
            ViewBag.Sizes = new SelectList(response.Size, "Id", "Name");

            response.Id = pizzaDetails.Id;
            response.CrustId = pizzaDetails.CrustID;
            response.SizeId = pizzaDetails.SizeID;
            response.Quantity = pizzaDetails.Quantity;
            response.Base_Price = pizzaDetails.Base_Price;
            response.Instructions = pizzaDetails.Instructions;


            foreach (var tp in pizzaDetails.ToppingsToPizzas)
            {
                var topping = response.Toppings.Where(t => t.Id == tp.ToppingID).FirstOrDefault();
                topping.IsChecked = true;
            }
            //var response = new NewPizzaVM()
            //{
            //    Id = pizzaDetails.Id,
            //    Size = pizzaDetails.Size,
            //    Quantity = pizzaDetails.Quantity,
            //    Base_Price = pizzaDetails.Base_Price,
            //    Instructions = pizzaDetails.Instructions
            //};


            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreatePizzaVM pizza)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Orders));
            }

            await _service.EditPizza(pizza);
            return RedirectToAction(nameof(Orders));
        }
    }
}
