﻿using PizzaBuilder.Data.Enums;
using PizzaBuilder.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaBuilder.Data.ViewModels
{
    public class NewPizzaVM
    {
        public int Id { get; set; }

        [Required]
        public PizzaSize Size { get; set; }

        [Required]
        public int Quantity { get; set; }
        public double Base_Price { get; set; }
        public string Instructions { get; set; }

        public int CrustIds { get; set; }
        public int ToppingIds{ get; set; }


    }
}
