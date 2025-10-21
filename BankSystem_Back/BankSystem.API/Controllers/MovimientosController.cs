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

        [HttpGet("cuenta/{id}")]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetAllMovimientosCuenta(int id)
        {
            var movimientos = await _movimientosService.GetAllByCuentaIdAsync(id);
            if (movimientos == null) return NotFound();
            return Ok(movimientos);
        }

        [HttpGet("cuenta/{id}/rango")]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetByRangoFechas(int id, DateTime limiteInferior, DateTime limiteSuperior)
        {
            var movimientos = await _movimientosService.GetByRangoFechaAsync(id, limiteInferior, limiteSuperior);
            if (movimientos == null) return NotFound();
            return Ok(movimientos);
        }
    }
}
