using biblioteca.Models;
using biblioteca.Data;
using Microsoft.EntityFrameworkCore;

namespace biblioteca.Services;

public class PacienteService
{

    private readonly BibliotecaContext _context;

    public PacienteService(BibliotecaContext context)
    {
        _context = context;
    }

    public IEnumerable<Paciente> GetAll()
    {

        return _context.Pacientes
        .AsNoTracking()
        .ToList();
    }

    public Paciente? GetById(int id)
    {
        return _context.Pacientes
        .AsNoTracking()
        .SingleOrDefault(p => p.PacienteId == id);
    }

    public Paciente Create(Paciente newPaciente)
    {
        _context.Pacientes!.Add(newPaciente);
        _context.SaveChanges();

        return newPaciente;
    }

    public void Update(int id, Paciente Paciente){
        var PacienteToUpdate = _context.Pacientes.Find(id);

        if (PacienteToUpdate is not null){
            PacienteToUpdate.Nombre = Paciente.Nombre;
            PacienteToUpdate.Apellido = Paciente.Apellido;
            PacienteToUpdate.FechaNacimiento = Paciente.FechaNacimiento;
            
            
            _context.SaveChanges();
        }

    }

    public void Delete(int id){
        var PacienteToDelete = _context.Pacientes.Find(id);

        if (PacienteToDelete is not null){
            _context.Pacientes.Remove(PacienteToDelete);
            _context.SaveChanges();
        }
    }

}