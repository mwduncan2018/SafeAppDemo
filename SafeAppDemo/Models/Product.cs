using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SafeAppDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]        
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public Product(int id, string manufacturer, string model, double price, int numberInStock)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            NumberInStock = numberInStock;
        }

        override
        public string ToString()
        {
            return 
                Manufacturer + " " + Model 
                + " ($" + Price.ToString("#.##") + ", " 
                + NumberInStock.ToString() + " in stock)";
        }
    }
}
