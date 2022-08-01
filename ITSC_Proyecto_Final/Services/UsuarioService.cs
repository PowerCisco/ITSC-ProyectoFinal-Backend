using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSC_Proyecto_Final.Services;

public class UsuarioService
{

    private readonly ITSC_Proyecto_FinalContext _context;

    public UsuarioService(ITSC_Proyecto_FinalContext context)
    {
        _context = context;
    }

    /*
    public IEnumerable<Usuario> GetAll()
    {

        return _context.Usuarios
        .AsNoTracking()
        .ToList();
    }
    */
    public Usuario? GetIniciarSesion(string nombreUsuario, string contrasena)
    {
        return _context.Usuarios
        .AsNoTracking()
        .SingleOrDefault(p => p.NombreUsuario == nombreUsuario && p.Contrasena == contrasena);
    }

    public Usuario Create(Usuario newUsuario)
    {
        _context.Usuarios!.Add(newUsuario);
        _context.SaveChanges();

        return newUsuario;
    }

    public void Update(int id, Usuario Usuario)
    {
        var UsuarioToUpdate = _context.Usuarios.Find(id);

        if (UsuarioToUpdate is not null)
        {
            UsuarioToUpdate.Contrasena = Usuario.Contrasena;
            UsuarioToUpdate.NombreUsuario = Usuario.NombreUsuario;
            _context.SaveChanges();
        }

    }

    public void Delete(int id)
    {
        var UsuarioToDelete = _context.Usuarios.Find(id);

        if (UsuarioToDelete is not null)
        {
            _context.Usuarios.Remove(UsuarioToDelete);
            _context.SaveChanges();
        }
    }

}