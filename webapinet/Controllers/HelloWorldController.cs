using Microsoft.AspNetCore.Mvc;
using webapinet.Services;

namespace webapinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    private ILogger<HelloWorldController> _logger;
    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Obteniendo un hola mundo.");
        return Ok(helloWorldService.GetHelloWorld());
    }
}
