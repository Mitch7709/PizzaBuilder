﻿using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;

namespace PizzaBuilder.Services
{
    public interface IPizzaService : IEntityBaseRepository<Pizza>
    {
        Task<NewPizzaVM> GetNewPizzaValues();
        Task<CreatePizzaVM> GetPizzaMenu();
        Task<List<Topping>> GetTemplateOptions(int tempId);
        Task AddNewPizza(NewPizzaVM data);
        Task<OrdersVM> GetPizzaOrders();

        Task<Pizza> GetPizzaById(int id);
        Task EditPizza(NewPizzaVM data);

        Task DeletePizza(int id);
    }
}
