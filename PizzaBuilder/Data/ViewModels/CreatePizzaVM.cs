﻿using PizzaBuilder.Models;

namespace PizzaBuilder.Data.ViewModels
{
    public class CreatePizzaVM
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public List<Sizes> Size { get; set; }
        public int Quantity { get; set; }
        public double Base_Price { get; set; }
        public string? Instructions { get; set; }
        public List<Topping> Toppings { get; set; }
        public int CrustId { get; set; }
        public List<Crust> Crusts { get; set; }

        public List<PizzaTemplate> Templates { get; set; }

        public CreatePizzaVM()
        {
            Size = new List<Sizes>();
            Quantity = 1;
            Base_Price = 12.99;
            Crusts = new List<Crust>();
            Toppings = new List<Topping>();
            Instructions = string.Empty;
            Templates = new List<PizzaTemplate>();
        }
    }
}
