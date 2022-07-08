using biblioteca.Models;
using biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController : ControllerBase
{

    public PacienteService _service;

    public PacienteController(PacienteService service)
    {
        _service = service;
    }

    // GET all action
    [HttpGet]
    public IEnumerable<Paciente> GetAll()
    {
        return _service.GetAll();
    }


    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Paciente> GetById(int id)
    {
        var Paciente = _service.GetById(id);

        if (Paciente is not null)
            return Paciente;
        else
            return NotFound();

    }

    // POST action
    [HttpPost]
    public IActionResult Create(Paciente newPaciente)
    {
        var Paciente = _service.Create(newPaciente);
        return CreatedAtAction(nameof(GetById), new { id = Paciente!.PacienteId }, Paciente);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Paciente Paciente){
        
        var PacienteToUpdate = _service.GetById(id);

        if (PacienteToUpdate is not null){
            _service.Update(id, Paciente);
            return Ok();
        }

        else {
            return NotFound();
        }

    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var PacienteToDelete = _service.GetById(id);

        if (PacienteToDelete is not null){
            _service.Delete(id);
            return Ok();
        }
        else
            return NotFound();


    }

}
