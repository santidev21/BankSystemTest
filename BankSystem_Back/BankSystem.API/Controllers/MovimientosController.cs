using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;
using BankSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : Controller
    {
        private IMovimientosService _movimientosService;

        public MovimientosController(IMovimientosService movimientoService)
        {
            _movimientosService = movimientoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearMovimientoDTO movimiento)
        {
            await _movimientosService.AddMovimientoAsync(movimiento);
            return Ok(movimiento);
        }

        [HttpGet]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetAll()
        {
            var movimientos = await _movimientosService.GetAllAsync();
            return Ok(movimientos);
        }

        [HttpGet("cuenta/{id}")]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetAllMovimientosCuenta(int id)
        {
            var movimientos = await _movimientosService.GetAllByCuentaIdAsync(id);
            if (movimientos == null) return NotFound();
            return Ok(movimientos);
        }

        [HttpPost("reporte")]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetByRangoFechas([FromBody] FiltroReporteDTO filtro)
        {
            var movimientos = await _movimientosService.GetByRangoFechaAsync(filtro);
            if (movimientos == null) return NotFound();
            return Ok(movimientos);
        }
    }
}
