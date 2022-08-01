using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITSC_Proyecto_Final.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    public UsuarioService _service;

    public UsuarioController(UsuarioService service)
    {
        _service = service;
    }

    // GET all action
   /*
       [HttpGet]
    public IEnumerable<Usuario> GetAll()
    {
        return _service.GetAll();
    }
   */




    // GET by Id action

    [HttpGet("{nombreusuario}/{contrasena}")]
    public ActionResult<Usuario> GetIniciarSesion(string nombreUsuario, string contrasena)
    {
        var Usuario = _service.GetIniciarSesion(nombreUsuario, contrasena);

        if (Usuario is not null)
            return Usuario;
        else
            return NotFound();

    }

/*
    // POST action
    [HttpPost]
    public IActionResult Create(Usuario newUsuario)
    {
        var Usuario = _service.Create(newUsuario);
        return CreatedAtAction(nameof(GetById), new { id = Usuario!.UsuarioId }, Usuario);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Usuario Usuario){
        
        var UsuarioToUpdate = _service.GetById(id);

        if (UsuarioToUpdate is not null){
            _service.Update(id, Usuario);
            return Ok();
        }

        else {
            return NotFound();
        }

    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var UsuarioToDelete = _service.GetById(id);

        if (UsuarioToDelete is not null){
            _service.Delete(id);
            return Ok();
        }
        else
            return NotFound();


    }

*/

}
