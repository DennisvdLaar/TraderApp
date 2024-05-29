using Microsoft.AspNetCore.Mvc;

namespace CeoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CeoController : ControllerBase
{
    private static readonly string[] Firstnames = new[]
    {
        "James", "John", "Christian", "Dirk", "Elianne", "Dennis", "Steve"
    };

    private static readonly string[] Lastnames = new[]
    {
        "Gosling", "Carmack", "Bale", "Gates", "Jobs", "Wozniak", "Ballmer"
    };

    private readonly ILogger<CeoController> _logger;

    public CeoController(ILogger<CeoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCeo")]
    public IEnumerable<CEO> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new CEO
        {
            Firstname = Firstnames[index],
            Lastname = Lastnames[index],
            IsFounder = index % 2 == 0
        })
        .ToArray();
    }
}
