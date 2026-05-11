using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyMvcApp.Models

{
    public class FahrzeugAktualisierenModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public List<SelectListItem> Typen { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "Auto", Value = "Auto", Selected = true },
            new SelectListItem { Text = "Motorrad", Value = "Motorrad" },
            new SelectListItem { Text = "LKW", Value = "LKW" }
        };
    }
}