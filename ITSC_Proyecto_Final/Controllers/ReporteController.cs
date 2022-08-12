using ITSC_Proyecto_Final.Models;
using ITSC_Proyecto_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITSC_Proyecto_Final.Controllers;

[ApiController]
[Route("[controller]")]
public class ReporteController : ControllerBase
{

    public ReporteService _service;

    public ReporteController(ReporteService service)
    {
        _service = service;
    }

    // GET all action
    [HttpGet]
    public IEnumerable<Reporte> Get([FromQuery] Filtro filtro)
    {
        return _service.GetReportes(filtro);
    }

    

}
