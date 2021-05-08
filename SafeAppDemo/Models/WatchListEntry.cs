using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SafeAppDemo.Models
{
    public class WatchListEntry
    {
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }

        public WatchListEntry(int id, string manufacturer, string model)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
        }

        override
        public string ToString()
        {
            return Manufacturer + " " + Model;
        }
    }
}
