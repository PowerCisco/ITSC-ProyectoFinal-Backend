using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSC_Proyecto_Final.Services;

public class AtencionService
{

    private readonly ITSC_Proyecto_FinalContext _context;

    public AtencionService(ITSC_Proyecto_FinalContext context)
    {
        _context = context;
    }

    public IEnumerable<Atencion> GetAll()
    {

        return _context.Atenciones
        .AsNoTracking()
        .ToList();
    }

    public Atencion? GetById(int id)
    {
        return _context.Atenciones
        .AsNoTracking()
        .SingleOrDefault(l => l.AtencionId == id);
    }

    public Atencion Create(Atencion newAtencion)
    {
        _context.Atenciones!.Add(newAtencion);
        _context.SaveChanges();

        return newAtencion;
    }

    public void Update(int id, Atencion atencion)
    {
        var AtencionToUpdate = _context.Atenciones.Find(id);

        if (AtencionToUpdate is not null)
        {
            AtencionToUpdate.Diagnostico = atencion.Diagnostico ?? AtencionToUpdate.Diagnostico;
            AtencionToUpdate.Tratamiento = atencion.Tratamiento ?? AtencionToUpdate.Tratamiento;
            AtencionToUpdate.FechaAtencion = atencion.FechaAtencion;
            AtencionToUpdate.MedicamentosIndicados = atencion.MedicamentosIndicados ?? AtencionToUpdate.MedicamentosIndicados;
            AtencionToUpdate.PacienteId = atencion.PacienteId;
            AtencionToUpdate.MedicoId = atencion.MedicoId;

            _context.SaveChanges();
        }

    }

    public void Delete(int id)
    {
        var AtencionToDelete = _context.Atenciones.Find(id);

        if (AtencionToDelete is not null)
        {
            _context.Atenciones.Remove(AtencionToDelete);
            _context.SaveChanges();
        }
    }

}