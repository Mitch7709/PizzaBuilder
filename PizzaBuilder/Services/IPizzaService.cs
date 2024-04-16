using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;

namespace PizzaBuilder.Services
{
    public interface IPizzaService : IEntityBaseRepository<Pizza>
    {
        Task<CreatePizzaVM> GetNewPizzaValues();
        Task<CreatePizzaVM> GetPizzaMenu();
        Task<List<Topping>> GetTemplateOptions(int tempId);
        Task AddNewPizza(CreatePizzaVM data);
        Task<OrdersVM> GetPizzaOrders();

        Task<Pizza> GetPizzaById(int id);
        Task EditPizza(CreatePizzaVM data);

        Task DeletePizza(int id);
    }
}
