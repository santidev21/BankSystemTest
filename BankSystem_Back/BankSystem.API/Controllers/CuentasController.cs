using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : Controller
    {
        private readonly ICuentasService _cuentaService;

        public CuentasController(ICuentasService cuentasService)
        {
            _cuentaService = cuentasService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CuentasDTO>>> GetAll()
        {
            var cuentas = await _cuentaService.GetAllAsync();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CuentasDTO>> GetById(int id)
        {
            var cuenta = await _cuentaService.GetByIdAsync(id);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearCuentaDTO cuenta)
        {
            await _cuentaService.AddAsync(cuenta);
            return Ok(cuenta);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CuentasDTO cuenta)
        {
            await _cuentaService.UpdateAsync(cuenta);
            return Ok(cuenta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cuentaService.DeleteAsync(id);
            return Ok();
        }
    }
}
