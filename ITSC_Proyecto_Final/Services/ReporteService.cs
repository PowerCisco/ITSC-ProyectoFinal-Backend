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

    public Paciente GetPaciente(Atencion atencion, string tipoPaciente = "todos")
    {
        var TipoPaciente = new
        {
            Estudiante = "Estudiante",
            Colaborador = "Colaborador",
            Externo = "Externo"
        };


        if (tipoPaciente == TipoPaciente.Estudiante)
        {
            return _context.Pacientes
            .AsNoTracking()
            .SingleOrDefault(p => p.PacienteId == atencion.PacienteId && p.TipoPaciente == TipoPaciente.Estudiante);
        }
        else if (tipoPaciente == TipoPaciente.Estudiante)
        {
            return _context.Pacientes
            .AsNoTracking()
            .SingleOrDefault(p => p.PacienteId == atencion.PacienteId && p.TipoPaciente == TipoPaciente.Colaborador);
        }
        else if (tipoPaciente == TipoPaciente.Estudiante)
        {
            return _context.Pacientes
            .AsNoTracking()
            .SingleOrDefault(p => p.PacienteId == atencion.PacienteId && p.TipoPaciente == TipoPaciente.Externo);
        }

        else
        {
            return _context.Pacientes
            .AsNoTracking()
            .SingleOrDefault(p => p.PacienteId == atencion.PacienteId);
        }


    }

    public string GetNombreCompletoPaciente(Paciente paciente)
    => paciente.Nombre + " " + paciente.Apellido;

    public string GetNombreCompletoMedico(Medico medico)
    => medico.PNombre + " " + medico.SNombre + " " + medico.PApellido + " " + medico.SApellido;

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

    public IEnumerable<Atencion> GetAtenciones(Filtro filtro)
    {
        return _context.Atenciones
        .AsNoTracking()
        .Where(a => a.FechaAtencion >= filtro.FechaInicio && a.FechaAtencion <= filtro.FechaFin)
        .ToList();
    }


    public IEnumerable<Reporte> GetReportes(Filtro filtro)
    {
        var atenciones = GetAtenciones(filtro);

        List<Reporte> reportes = new List<Reporte>();

        foreach (var atencion in atenciones)
        {

            var paciente = GetPaciente(atencion);
            var reporte = new Reporte();
            var medico = GetMedico(atencion);

            if (filtro.TipoPaciente == "Estudiante" && paciente.TipoPaciente == "Estudiante")
            {
                reporte.Edad = GetEdad(paciente.FechaNacimiento);
                reporte.Fecha = atencion.FechaAtencion.ToShortDateString();
                reporte.NombreCompleto = GetNombreCompletoPaciente(paciente);
                reporte.Carrera = paciente.Carrera;
                reporte.Matricula = paciente.Matricula;
                reporte.Diagnostico = atencion.Diagnostico;
                reporte.Tratamiento = atencion.Tratamiento;
                reporte.Medico = GetNombreCompletoMedico(medico);
                reportes.Add(reporte);
                continue;
            }

            else if (filtro.TipoPaciente == "Colaborador" && paciente.TipoPaciente == "Colaborador")
            {
                reporte.Edad = GetEdad(paciente.FechaNacimiento);
                reporte.Fecha = atencion.FechaAtencion.ToShortDateString();
                reporte.NombreCompleto = GetNombreCompletoPaciente(paciente);
                reporte.Departamento = paciente.Departamento;
                reporte.Diagnostico = atencion.Diagnostico;
                reporte.Tratamiento = atencion.Tratamiento;
                reporte.Medico = GetNombreCompletoMedico(medico);
                reportes.Add(reporte);
                continue;
            }

            else if (filtro.TipoPaciente == "Externo" && paciente.TipoPaciente == "Externo")
            {
                reporte.Edad = GetEdad(paciente.FechaNacimiento);
                reporte.Fecha = atencion.FechaAtencion.ToShortDateString();
                reporte.NombreCompleto = GetNombreCompletoPaciente(paciente);
                reporte.Telefono = paciente.Telefono;
                reporte.Diagnostico = atencion.Diagnostico;
                reporte.Tratamiento = atencion.Tratamiento;
                reporte.Medico = GetNombreCompletoMedico(medico);
                reportes.Add(reporte);
                continue;
            }

            else
            {
                reporte.Edad = GetEdad(paciente.FechaNacimiento);
                reporte.Fecha = atencion.FechaAtencion.ToShortDateString();
                reporte.NombreCompleto = GetNombreCompletoPaciente(paciente);
                reporte.Telefono = paciente.Telefono;
                reporte.Carrera = paciente.Carrera;
                reporte.Matricula = paciente.Matricula;
                reporte.Departamento = paciente.Departamento;
                reporte.Diagnostico = atencion.Diagnostico;
                reporte.Tratamiento = atencion.Tratamiento;
                reporte.Medico = GetNombreCompletoMedico(medico);
                reportes.Add(reporte);
                continue;
            }
        }
        return reportes;
    }
}