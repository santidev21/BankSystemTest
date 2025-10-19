using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : Controller
    {
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientosController(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        [HttpGet("cuenta/{id}")]
        public async Task<ActionResult<IList<Cuenta>>> GetAllMovimientosCuenta(int id)
        {
            var movimientos = await _movimientoRepository.GetAllByCuentaIdAsync(id);
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> GetById(int id)
        {
            var movimiento = await _movimientoRepository.GetByIdAsync(id);
            if (movimiento == null) return NotFound();
            return Ok(movimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movimiento movimiento)
        {
            await _movimientoRepository.AddAsync(movimiento);
            return Ok(movimiento);
        }

        [HttpGet("cuenta/{id}/rango")]
        public async Task<ActionResult<IList<Cuenta>>> GetByRangoFechas(int id, DateTime limiteInferior, DateTime limiteSuperior)
        {
            var movimientos = await _movimientoRepository.GetByRangoFechaAsync(id, limiteInferior, limiteSuperior);
            return Ok(movimientos);
        }
    }
}
