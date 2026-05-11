using Microsoft.AspNetCore.Mvc;
using MyLibrary;

[ApiController]
[Route("api/v1/[controller]")]
public class FahrzeugApiController : ControllerBase
{
    private readonly FahrzeugRepository _fahrzeugRepository;

    public FahrzeugApiController(FahrzeugRepository fahrzeugRepository)
    {
        _fahrzeugRepository = fahrzeugRepository;
    }

    [HttpGet(Name = "GetFahrzeuge")]
    public IEnumerable<FahrzeugDTO> Get()
    {
        return _fahrzeugRepository.GetFahrzeuge();
    }

    [HttpGet(Name = "GetFahrzeugPerId")]
    public IEnumerable<FahrzeugDTO> GetmitId(int id)
    {
        return _fahrzeugRepository.GetFahrzeuge().Where(f => f.Id == id);
    }
}