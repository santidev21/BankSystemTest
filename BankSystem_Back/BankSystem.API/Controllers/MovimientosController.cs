using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Infrastructure.Exceptions;
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
            try
            {
                await _movimientosService.AddMovimientoAsync(movimiento);
                return Ok(movimiento);
            }
            catch (BankSystemException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetAll()
        {
            try
            {
                var movimientos = await _movimientosService.GetAllAsync();
                return Ok(movimientos);
            }
            catch (BankSystemException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpGet("cuenta/{id}")]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetAllMovimientosCuenta(int id)
        {
            try
            {
                var movimientos = await _movimientosService.GetAllByCuentaIdAsync(id);
                if (movimientos == null) return NotFound();
                return Ok(movimientos);
            }
            catch (BankSystemException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost("reporte")]
        public async Task<ActionResult<IList<MovimientosDTO>>> GetByRangoFechas([FromBody] FiltroReporteDTO filtro)
        {
            try
            {
                var movimientos = await _movimientosService.GetByRangoFechaAsync(filtro);
                if (movimientos == null) return NotFound();
                return Ok(movimientos);
            }
            catch (BankSystemException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}
