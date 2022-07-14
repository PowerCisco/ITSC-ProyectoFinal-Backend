using biblioteca.Models;
using biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class AtencionController : ControllerBase
{

    public AtencionService _service;

    public AtencionController(AtencionService service)
    {
        _service = service;
    }

    // GET all action
    [HttpGet]
    public IEnumerable<Atencion> GetAll()
    {
        return _service.GetAll();
    }


    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Atencion> GetById(int id)
    {
        var Atencion = _service.GetById(id);

        if (Atencion is not null)
            return Atencion;
        else
            return NotFound();

    }

    // POST action
    [HttpPost]
    public IActionResult Create(Atencion newAtencion)
    {
        var Atencion = _service.Create(newAtencion);

        return CreatedAtAction(nameof(GetById), new { id = Atencion!.AtencionId }, Atencion);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Atencion Atencion)
    {

        var AtencionToUpdate = _service.GetById(id);

        if (AtencionToUpdate is not null)
        {
            
            _service.Update(id, Atencion);
            return Ok();
        }

        else
        {
            return NotFound();
        }

    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var AtencionToDelete = _service.GetById(id);

        if (AtencionToDelete is not null)
        {
            _service.Delete(id);
            return Ok();
        }
        else
            return NotFound();


    }

}
