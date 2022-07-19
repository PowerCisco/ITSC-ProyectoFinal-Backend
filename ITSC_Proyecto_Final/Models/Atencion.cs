namespace ITSC_Proyecto_Final.Models;


public class Atencion{
    public int AtencionId {get;set;}
    public string Diagnostico {get;set;}
    public string Tratamiento {get;set;}
    public DateTime FechaAtencion {get;set;}

    public string? MedicamentosIndicados {get;set;}


    public int PacienteId {get;set;}
    public int MedicoId {get;set;}
    // public Paciente? Paciente {get;set;}
    // public Medico? Medico {get;set;}
}