using PizzaBuilder.Models;

namespace PizzaBuilder.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                context.Database.EnsureCreated();

                //Crust
                if (!context.Crusts.Any())
                {
                    context.Crusts.AddRange(new List<Crust>()
                    {
                        new Crust()
                        {
                            Name = "Original",
                            Calories = 271
                        },
                        new Crust()
                        {
                            Name = "Thin",
                            Calories = 116
                        },
                        new Crust()
                        {
                            Name = "Lite",
                            Calories = 226
                        },
                        new Crust()
                        {
                            Name = "Thick",
                            Calories = 325
                        }
                    });
                    context.SaveChanges();
                }
                //Sizes
                if (!context.Sizes.Any())
                {
                    context.Sizes.AddRange(new List<Sizes>()
                    {
                        new Sizes()
                        {
                            Name = "Small",
                            Calories = 50,
                            Price = .70
                        },
                        new Sizes()
                        {
                            Name = "Medium",
                            Calories = 75,
                            Price = 1.02
                        },
                        new Sizes()
                        {
                            Name = "Large",
                            Calories = 145,
                            Price = 4.35
                        }
                    });
                    context.SaveChanges();
                }
                //Toppings
                if (!context.Toppings.Any())
                {

                    context.Toppings.AddRange(new List<Topping>() 
                    {
                        new Topping()
                        {
                            Name = "Pepperoni",
                            Price = 2.58,
                            Category = "Meat",
                            Calories = 49,
                            ImageUrl = "Images\\pepperoni.png"
                        },
                        new Topping()
                        {
                            Name = "Bacon",
                            Price = 2.58,
                            Category = "Meat",
                            Calories = 43,
                            ImageUrl = "Images\\bacon.png"
                        },
                        new Topping()
                        {
                            Name = "Italian Sausage",
                            Price = 2.58,
                            Category = "Meat",
                            Calories = 59,
                            ImageUrl = "Images\\italian-sausage.png"
                        },
                        new Topping()
                        {
                            Name = "Ham",
                            Price = 2.58,
                            Category = "Meat",
                            Calories = 17,
                            ImageUrl = "Images\\ham.jpg"
                        },
                        new Topping()
                        {
                            Name = "Beef",
                            Price = 2.58,
                            Category = "Meat",
                            Calories = 36,
                            ImageUrl = "Images\\beef.jpg"
                        },
                        new Topping()
                        {
                            Name = "Mushroom",
                            Price = 2.58,
                            Category = "Vegetable",
                            Calories = 2,
                            ImageUrl = "Images\\mushroom.png"
                        },
                        new Topping()
                        {
                            Name = "Onions",
                            Price = 2.58,
                            Category = "Vegetable",
                            Calories = 4,
                            ImageUrl = "Images\\onions.png"
                        },
                        new Topping()
                        {
                            Name = "Green Peppers",
                            Price = 2.58,
                            Category = "Vegetable",
                            Calories = 2,
                            ImageUrl = "Images\\green-pepper.jpg"
                        },
                        new Topping()
                        {
                            Name = "Black Olives",
                            Price = 2.58,
                            Category = "Vegetable",
                            Calories = 19,
                            ImageUrl = "Images\\black-olive.jpg"
                        },
                    });
                    context.SaveChanges();
                }
                //Templates
                if (!context.PizzaTemplates.Any())
                {
                    context.PizzaTemplates.AddRange(new List<PizzaTemplate>()
                    {
                        new PizzaTemplate()
                        {
                            Name = "Create your own",
                            Description = "Start from scratch and create your own pizza!",
                            TemplateToppings = new List<TemplateToppings>()
                        },
                        new PizzaTemplate()
                        {
                            Name = "Meat Lovers",
                            Description = "Pepperoni, ham, Italian sausage, and bacon!",
                            TemplateToppings = new List<TemplateToppings>()
                            {
                                new TemplateToppings()
                                {
                                    ToppingID = 1
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 2
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 3
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 4
                                }
                            }
                        },
                        new PizzaTemplate()
                        {
                            Name = "Supreme",
                            Description = "Pepperoni, Italian sausage, mushrooms, green peppers, and onions!",
                            TemplateToppings = new List<TemplateToppings>()
                            {
                                new TemplateToppings()
                                {
                                    ToppingID = 1
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 3
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 6
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 7
                                },
                                new TemplateToppings()
                                {
                                    ToppingID = 8
                                }
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
