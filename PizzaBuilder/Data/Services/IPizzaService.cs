using PizzaBuilder.Data.Base;
using PizzaBuilder.Data.ViewModels;
using PizzaBuilder.Models;

namespace PizzaBuilder.Data.Services
{
    public interface IPizzaService : IEntityBaseRepository<Pizza>
    {
        Task<NewPizzaDropdownsVM> GetNewPizzaDropDownValues();
    }
}
