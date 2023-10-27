using Microsoft.EntityFrameworkCore;
using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;

namespace PizzaBuilder.Data.Services
{
    public class PizzaService : EntityBaseRepository<Pizza>, IPizzaService
    {
        private readonly AppDBContext _context;

        public PizzaService(AppDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<NewPizzaDropdownsVM> GetNewPizzaDropDownValues()
        {
            var response = new NewPizzaDropdownsVM();
            response.Crusts = await _context.Crusts.OrderBy(n => n.Id).ToListAsync();
            response.Toppings = await _context.Toppings.OrderBy(n => n.Id).ToListAsync();

            return response;
        }
    }
}
