using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSC_Proyecto_Final.Services;

public class PacienteService
{

    private readonly ITSC_Proyecto_FinalContext _context;

    public PacienteService(ITSC_Proyecto_FinalContext context)
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

    public void Update(int id, Paciente Paciente)
    {
        var PacienteToUpdate = _context.Pacientes.Find(id);

        if (PacienteToUpdate is not null)
        {

            PacienteToUpdate.Nombre = Paciente.Nombre;
            PacienteToUpdate.Apellido = Paciente.Apellido;
            PacienteToUpdate.FechaNacimiento = Paciente.FechaNacimiento;
            PacienteToUpdate.TipoPaciente = Paciente.TipoPaciente;
            PacienteToUpdate.Carrera = Paciente.Carrera;
            PacienteToUpdate.Matricula = Paciente.Matricula;
            PacienteToUpdate.Departamento = Paciente.Departamento;
            PacienteToUpdate.Telefono = Paciente.Telefono;
            PacienteToUpdate.Sexo = Paciente.Sexo;

            _context.SaveChanges();
        }

    }

    public void Delete(int id)
    {
        var PacienteToDelete = _context.Pacientes.Find(id);

        if (PacienteToDelete is not null)
        {
            _context.Pacientes.Remove(PacienteToDelete);
            _context.SaveChanges();
        }
    }

}