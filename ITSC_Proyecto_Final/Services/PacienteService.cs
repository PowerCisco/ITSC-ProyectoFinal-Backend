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

            PacienteToUpdate.Nombre = Paciente.Nombre ?? PacienteToUpdate.Nombre;
            PacienteToUpdate.Apellido = Paciente.Apellido ?? PacienteToUpdate.Apellido;
            PacienteToUpdate.FechaNacimiento = Paciente.FechaNacimiento;
            PacienteToUpdate.TipoPaciente = Paciente.TipoPaciente ?? PacienteToUpdate.TipoPaciente;
            PacienteToUpdate.Carrera = Paciente.Carrera ?? PacienteToUpdate.Carrera;
            PacienteToUpdate.Matricula = Paciente.Matricula ?? PacienteToUpdate.Matricula;
            PacienteToUpdate.Departamento = Paciente.Departamento ?? PacienteToUpdate.Departamento;
            PacienteToUpdate.Telefono = Paciente.Telefono ?? PacienteToUpdate.Telefono;
            PacienteToUpdate.Sexo = Paciente.Sexo ?? PacienteToUpdate.Sexo;

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