using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaBuilder.Data;
using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;
using System.Net.WebSockets;

namespace PizzaBuilder.Services
{
    public class PizzaService : EntityBaseRepository<Pizza>, IPizzaService
    {
        private readonly AppDBContext _context;

        public PizzaService(AppDBContext context) : base(context)
        {
            _context = context;
        }

        #region Create
        public async Task AddNewPizza(CreatePizzaVM data)
        {
            
            
            var newPizza = new Pizza()
            {
                SizeID = data.SizeId,
                CrustID = data.CrustId,
                Quantity = data.Quantity,
                Total_Price = data.Base_Price,
                Instructions = data.Instructions

            };

            await _context.Pizzas.AddAsync(newPizza);
            await _context.SaveChangesAsync();

            //Add Pizza Toppings
            foreach (var t in data.Toppings)
            {
                if (t.IsChecked == true)
                {
                    var newPizzaTopping = new ToppingsToPizza()
                    {
                        PizzaID = newPizza.Id,
                        ToppingID = t.Id
                    };
                    await _context.ToppingsToPizzas.AddAsync(newPizzaTopping);
                }

            }
            await _context.SaveChangesAsync();

        }

        public async Task<CreatePizzaVM> GetNewPizzaValues()
        {
            var response = new CreatePizzaVM();
            response.Crusts = await _context.Crusts.OrderBy(n => n.Id).ToListAsync();
            response.Size = await _context.Sizes.OrderBy(n => n.Id).ToListAsync();
            response.Toppings = await _context.Toppings.OrderBy(n => n.Id).ToListAsync();

            return response;
        }

        public async Task<CreatePizzaVM> GetPizzaMenu()
        {
            var response = new CreatePizzaVM();
            response.Crusts = await _context.Crusts.OrderBy(n => n.Id).ToListAsync();
            response.Toppings = await _context.Toppings.OrderBy(n => n.Id).ToListAsync();
            response.Size = await _context.Sizes.OrderBy(n => n.Id).ToListAsync();
            response.Templates = await _context.PizzaTemplates.OrderBy(n => n.Id).ToListAsync();

            return response;
        }

        public async Task<List<Topping>> GetTemplateOptions(int tempId)
        {
            var tempToppings = await _context.TemplateToppings.Where(n => n.TemplateID == tempId).ToListAsync();
            var toppings = await _context.Toppings.ToListAsync();

            var returnToppings = new List<Topping>();
            foreach (var t in tempToppings)
            {
                var topping = toppings.Where(n => n.Id == t.ToppingID).FirstOrDefault();
                topping.IsChecked = true;
                returnToppings.Add(topping);
            }

            return returnToppings;
        }

        #endregion

        #region Orders

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _context.Pizzas
                .Include(c => c.Crust)
                .Include(tp => tp.ToppingsToPizzas).ThenInclude(t => t.Topping)
                .FirstOrDefaultAsync(n => n.Id == id);

            return pizza;
        }

        public async Task<OrdersVM> GetPizzaOrders()
        {
            var orders = new OrdersVM();

            orders.Pizzas = await _context.Pizzas
                .Include(c => c.Crust)
                .Include(s => s.Size)
                .Include(tp => tp.ToppingsToPizzas).ThenInclude(t => t.Topping)
                .ToListAsync();

            return orders;
        }

        #endregion


        public async Task EditPizza(CreatePizzaVM data)
        {
            var dbPizza = await _context.Pizzas.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPizza != null)
            {
                //dbPizza.Size = data.Size;
                dbPizza.Quantity = data.Quantity;
                dbPizza.CrustID = dbPizza.CrustID;
                dbPizza.Total_Price = data.Base_Price;
                dbPizza.Instructions = data.Instructions;
            }

            //Remove existing toppings
            var existingTPs = _context.ToppingsToPizzas.Where(n => n.PizzaID == data.Id).ToList();
            _context.ToppingsToPizzas.RemoveRange(existingTPs);
            await _context.SaveChangesAsync();

            //Add Pizza Toppings
            foreach (var t in data.Toppings)
            {
                if (t.IsChecked == true)
                {
                    var newPizzaTopping = new ToppingsToPizza()
                    {
                        PizzaID = data.Id,
                        ToppingID = t.Id
                    };
                    await _context.ToppingsToPizzas.AddAsync(newPizzaTopping);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(n => n.Id == id);

            if (pizza != null)
            {
                EntityEntry entry = _context.Entry(pizza);
                entry.State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

    }
}
