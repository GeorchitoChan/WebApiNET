using Microsoft.AspNetCore.Mvc;
using webapinet.Services;

namespace webapinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbContext;
    private ILogger<HelloWorldController> _logger;
    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Obteniendo un hola mundo.");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();

        return Ok();
    }
}
