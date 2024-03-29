using Microsoft.EntityFrameworkCore;
using PizzaBuilder.Models;

namespace PizzaBuilder.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToppingsToPizza>().HasKey(am => new
            {
                am.PizzaID,
                am.ToppingID
            });
            modelBuilder.Entity<TemplateToppings>().HasKey(am => new
            {
                am.TemplateID,
                am.ToppingID
            });

            modelBuilder.Entity<ToppingsToPizza>().HasOne(m => m.Pizza).WithMany(am => am.ToppingsToPizzas).HasForeignKey(m => m.PizzaID);
            modelBuilder.Entity<ToppingsToPizza>().HasOne(m => m.Topping).WithMany(am => am.ToppingsToPizzas).HasForeignKey(m => m.ToppingID);

            modelBuilder.Entity<TemplateToppings>().HasOne(m => m.Template).WithMany(am => am.TemplateToppings).HasForeignKey(m => m.TemplateID);
            modelBuilder.Entity<TemplateToppings>().HasOne(m => m.Topping).WithMany(am => am.TemplateToppings).HasForeignKey(m => m.ToppingID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<ToppingsToPizza> ToppingsToPizzas { get;set; }
        public DbSet<PizzaTemplate> PizzaTemplates { get; set; }
        public DbSet<TemplateToppings> TemplateToppings { get; set; }

        //Order related tables
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}
