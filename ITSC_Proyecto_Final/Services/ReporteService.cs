using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSC_Proyecto_Final.Services;

public class ReporteService
{

    private readonly ITSC_Proyecto_FinalContext _context;

    public ReporteService(ITSC_Proyecto_FinalContext context)
    {
        _context = context;
    }

    public Paciente GetPaciente(Atencion atencion)
    {
        return _context.Pacientes
        .AsNoTracking()
        .SingleOrDefault(p => p.PacienteId == atencion.PacienteId);

    }

    public string GetNombreCompletoPaciente(Paciente paciente) 
    => paciente.Nombre + " " + paciente.Apellido;

    public string GetNombreCompletoMedico(Medico medico) 
    =>  medico.PNombre + " " + medico.SNombre + " " + medico.PApellido +" " + medico.SApellido;

    public int GetEdad(DateTime fechaNacimiento)
    {
        var hoy = DateTime.Today;

        var edad = hoy.Year - fechaNacimiento.Year;
        return fechaNacimiento.Date > hoy.AddYears(-edad) ? edad : edad - 1;

        // expresion a evaluar ? verdadero : falso
    }

    public Medico GetMedico(Atencion atencion)
    {
        return _context.Medicos
        .AsNoTracking()
        .SingleOrDefault(m => m.MedicoId == atencion.MedicoId);
    }

    public IEnumerable<Atencion> GetAtenciones(DateTime fechaInicio, DateTime fechaFin)
    {
        return _context.Atenciones
        .AsNoTracking()
        .Where(a => a.FechaAtencion >= fechaInicio && a.FechaAtencion <= fechaFin)
        .ToList();
    }

    public IEnumerable<Reporte> GetReportes(DateTime fechaInicio, DateTime fechaFin)
    {
        var atenciones = GetAtenciones(fechaInicio, fechaFin);

        List<Reporte> reportes = new List<Reporte>();

            // public string? Fecha { get; set; }
            // public string? NombreCompleto { get; set; }
            // public int? Edad { get; set; }
            // public string? Telefono { get; set; }
            // public string? Diagnostico { get; set; }
            // public string? Tratamiento { get; set; }
            // public string? Medico { get; set; }

        foreach (var item in atenciones)
        {
            var reporte = new Reporte();
            var paciente = GetPaciente(item);
            var medico = GetMedico(item);
            reporte.Edad = GetEdad(paciente.FechaNacimiento);
            reporte.Fecha = item.FechaAtencion.ToShortDateString();
            reporte.NombreCompleto = GetNombreCompletoPaciente(paciente);
            reporte.Telefono = paciente.Telefono;
            reporte.Diagnostico = item.Diagnostico;
            reporte.Tratamiento = item.Tratamiento;
            reporte.Medico = GetNombreCompletoMedico(medico);

            reportes.Add(reporte);
        }

        return reportes;
    }

}