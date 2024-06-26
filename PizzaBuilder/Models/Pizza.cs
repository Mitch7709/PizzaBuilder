﻿using PizzaBuilder.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBuilder.Models
{
    public class Pizza:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int SizeID { get; set; }
        [ForeignKey("SizeID")]
        public Sizes Size { get; set; }
        public int Quantity { get; set; }

        [DisplayName("Price")]
        public double Total_Price { get; set; }

        public int CrustID { get; set; }
        [ForeignKey("CrustID")]
        public Crust Crust { get; set; }
        public string? Instructions { get; set; }

        public List<ToppingsToPizza> ToppingsToPizzas { get; set; }

    }
}
