using MyLibrary;

namespace MyMvcApp.Models
{
    public class FahrzeugListeModel
    {
        public List<FahrzeugDTO> Fahrzeuge { get; set; } = new();
    }
}