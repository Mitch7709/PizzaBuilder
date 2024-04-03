using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using PizzaBuilder.Controllers;
using PizzaBuilder.Data;
using PizzaBuilder.Models;
using PizzaBuilder.Services;

namespace PizzaBuilderTest
{
    public class CreateTest
    {
        [Fact]
        public void GetTemplateOptions()
        {
            var tempId = 2;

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "PizzaBuilder")
                .Options;

            using (var context = new AppDBContext(options))
            {
                var service = new PizzaService(context);
                var result = service.GetTemplateOptions(tempId).Result;

                Assert.NotNull(result);
            }
        }
    }
}