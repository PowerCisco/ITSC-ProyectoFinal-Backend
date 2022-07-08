using biblioteca.Models;
using biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorController : ControllerBase
{

    public AutorService _service;

    public AutorController(AutorService service)
    {
        _service = service;
    }

    // GET all action
    [HttpGet]
    public IEnumerable<Autor> GetAll()
    {
        return _service.GetAll();
    }


    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Autor> GetById(int id)
    {
        var Autor = _service.GetById(id);

        if (Autor is not null)
            return Autor;
        else
            return NotFound();

    }

    // POST action
    [HttpPost]
    public IActionResult Create(Autor newAutor)
    {
        var Autor = _service.Create(newAutor);
        return CreatedAtAction(nameof(GetById), new { id = Autor!.AutorId }, Autor);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Autor Autor){
        
        var AutorToUpdate = _service.GetById(id);

        if (AutorToUpdate is not null){
            _service.Update(id, Autor);
            return Ok();
        }

        else {
            return NotFound();
        }

    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var AutorToDelete = _service.GetById(id);

        if (AutorToDelete is not null){
            _service.Delete(id);
            return Ok();
        }
        else
            return NotFound();


    }

}
