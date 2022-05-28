using Microsoft.AspNetCore.Mvc;
using webapinet.Services;
using webapinet.Models;

namespace webapinet.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService service)
    {
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}
