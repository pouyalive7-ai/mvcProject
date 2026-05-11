using Microsoft.AspNetCore.Mvc;
using MyLibrary;
using MyMvcApp.Models;


public class FahrzeugController : Controller
{
    private readonly FahrzeugRepository _fahrzeugRepository;
    public FahrzeugController(FahrzeugRepository fahrzeugRepository)
    {
        _fahrzeugRepository=fahrzeugRepository;
    }

    public IActionResult Index()
    {

        var model = new FahrzeugListeModel()
        {
            Fahrzeuge= _fahrzeugRepository.GetFahrzeuge()
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Einfuegen()
    {
        var model = new FahrzeugEinfuegenModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Einfuegen(FahrzeugEinfuegenModel model)
    {
        if (ModelState.IsValid)
        {
            var fahrzeug = new FahrzeugDTO
            {
                Name = model.Name,
                Typ = model.Type
            };
            _fahrzeugRepository.addFahrzeug(fahrzeug);
            return RedirectToAction("Index");
        }
        return View(model);
    
}


    [HttpGet]
    public IActionResult Loeschen(int id)
    {
        var fahrzeug = _fahrzeugRepository.GetFahrzeuge().FirstOrDefault(f => f.Id == id);
        if (fahrzeug == null)        {
            return NotFound();
        }       
        var model = new FahrzeugLoeschenModel
        {
            Id = fahrzeug.Id,
            Name = fahrzeug.Name
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Loeschen(FahrzeugLoeschenModel model)
    {
        _fahrzeugRepository.deleteFahrzeug(model.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Aktualisieren(int id)
    {
        var fahrzeug = _fahrzeugRepository.GetFahrzeuge().FirstOrDefault(f => f.Id == id);
        if (fahrzeug == null)
        {
            return NotFound();
        }
        var model = new FahrzeugAktualisierenModel
        {
            Id = fahrzeug.Id,
            Name = fahrzeug.Name,
            Type = fahrzeug.Typ
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Aktualisieren(FahrzeugAktualisierenModel model)
    {
        var fahrzeug = _fahrzeugRepository.GetFahrzeuge().FirstOrDefault(f => f.Id == model.Id);
        if (fahrzeug == null)
        {
            return NotFound();
        }
        fahrzeug.Name = model.Name;
        fahrzeug.Typ = model.Type;
        fahrzeug.Id = model.Id;

        _fahrzeugRepository.updateFahrzeug(fahrzeug.Id, fahrzeug.Name, fahrzeug.Typ);
        return RedirectToAction("Index");
    }
}