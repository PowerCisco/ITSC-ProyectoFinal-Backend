using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSC_Proyecto_Final.Services;

public class MedicoService
{

    private readonly ITSC_Proyecto_FinalContext _context;

    public MedicoService(ITSC_Proyecto_FinalContext context)
    {
        _context = context;
    }

    public IEnumerable<Medico> GetAll()
    {

        return _context.Medicos
        .AsNoTracking()
        .ToList();
    }

    public Medico? GetById(int id)
    {

        return _context.Medicos
        .AsNoTracking()
        .SingleOrDefault(l => l.MedicoId == id);
    }

    public Medico Create(Medico newMedico)
    {
        _context.Medicos!.Add(newMedico);
        _context.SaveChanges();

        return newMedico;
    }

    public void Update(int id, Medico Medico)
    {
        var MedicoToUpdate = _context.Medicos.Find(id);

        if (MedicoToUpdate is not null)
        {
            
            MedicoToUpdate.PNombre = Medico.PNombre ?? MedicoToUpdate.PNombre;
            MedicoToUpdate.SNombre = Medico.SNombre ?? MedicoToUpdate.SNombre;
            MedicoToUpdate.PApellido = Medico.PApellido ?? MedicoToUpdate.PApellido;
            MedicoToUpdate.SApellido = Medico.SApellido ?? MedicoToUpdate.SApellido;
            MedicoToUpdate.Especialidad = Medico.Especialidad ?? MedicoToUpdate.Especialidad;
            MedicoToUpdate.Email = Medico.Email ?? MedicoToUpdate.Email;

            _context.SaveChanges();
        }

    }

    public void Delete(int id)
    {
        var MedicoToDelete = _context.Medicos.Find(id);

        if (MedicoToDelete is not null)
        {
            _context.Medicos.Remove(MedicoToDelete);
            _context.SaveChanges();
        }
    }

}