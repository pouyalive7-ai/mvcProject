using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyMvcApp.Models
{
    public class FahrzeugEinfuegenModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public List<SelectListItem> Typen { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "Auto", Value = "Auto", Selected = true },
            new SelectListItem { Text = "Motorrad", Value = "Motorrad" },
            new SelectListItem { Text = "LKW", Value = "LKW" }
        };
    }
}