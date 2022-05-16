using biblioteca.Models;
using biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class LibroController : ControllerBase
{

    public LibroService _service;

    public LibroController(LibroService service)
    {
        _service = service;
    }

    // GET all action
    [HttpGet]
    public IEnumerable<Libro> GetAll()
    {
        return _service.GetAll();
    }


    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Libro> GetById(int id)
    {
        var libro = _service.GetById(id);

        if (libro is not null)
            return libro;
        else
            return NotFound();

    }

    // POST action
    [HttpPost]
    public IActionResult Create(Libro newLibro)
    {
        var libro = _service.Create(newLibro);
        return CreatedAtAction(nameof(GetById), new { id = libro!.Id }, libro);
    }

    // PUT action

    // DELETE action
}
