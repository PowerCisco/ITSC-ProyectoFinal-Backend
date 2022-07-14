using biblioteca.Models;
using biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController : ControllerBase
{
    public MedicoService _service;
    public MedicoController(MedicoService service) => _service = service;


    //GET all action
    [HttpGet]
    public IEnumerable<Medico> GetAll()
    {
        return _service.GetAll();
    }



    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Medico> GetById(int id)
    {
        
        var Medico = _service.GetById(id);

        if (Medico is not null)
            return Ok(Medico);
        else
            return NotFound();

    }

    // POST action
    [HttpPost]
    public IActionResult Create(Medico newMedico)
    {
        var Medico = _service.Create(newMedico);
        return CreatedAtAction(nameof(GetById), new { id = Medico!.MedicoId }, Medico);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Medico Medico)
    {

        var MedicoToUpdate = _service.GetById(id);

        if (MedicoToUpdate is not null)
        {
            _service.Update(id, Medico);
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
        var MedicoToDelete = _service.GetById(id);

        if (MedicoToDelete is not null)
        {
            _service.Delete(id);
            return Ok();
        }
        else
            return NotFound();


    }

}
