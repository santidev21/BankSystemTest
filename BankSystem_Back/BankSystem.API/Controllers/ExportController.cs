using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExportController : Controller
    {
        private IExportService _reportesService;
        public ExportController(IExportService reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpPost("reporte")]
        public async Task<ActionResult> ExportarMovimientos([FromBody] FiltroReporteDTO filtro)
        {
            var pdfBytes = await _reportesService.ExportarMovimientos(filtro);
            return File(pdfBytes, "application/pdf", "reporte_movimientos.pdf");
        }
    }
}
