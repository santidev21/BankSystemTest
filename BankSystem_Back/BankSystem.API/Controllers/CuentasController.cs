using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : Controller
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentasController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CuentasDTO>>> GetAll()
        {
            var cuentas = await _cuentaRepository.GetAllAsync();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CuentasDTO>> GetById(int id)
        {
            var cuenta = await _cuentaRepository.GetByIdAsync(id);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearCuentaDTO cuenta)
        {
            await _cuentaRepository.AddAsync(cuenta);
            return Ok(cuenta);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CuentasDTO cuenta)
        {
            await _cuentaRepository.UpdateAsync(cuenta);
            return Ok(cuenta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cuentaRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
