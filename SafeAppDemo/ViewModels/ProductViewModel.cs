using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafeAppDemo.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
        [Display(Name = "Watch List?")]
        public bool IsOnWatchList { get; set; }
    }
}
