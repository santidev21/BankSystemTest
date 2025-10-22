using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Infrastructure.Exceptions;
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
            try
            {
                var cuentas = await _cuentaService.GetAllAsync();
                return Ok(cuentas);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CuentasDTO>> GetById(int id)
        {
            try
            {
                var cuenta = await _cuentaService.GetByIdAsync(id);
                if (cuenta == null) return NotFound();
                return Ok(cuenta);
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

        [HttpPost]
        public async Task<IActionResult> Create(CrearCuentaDTO cuenta)
        {
            try
            {
                await _cuentaService.AddAsync(cuenta);
                return Ok(cuenta);
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

        [HttpPut]
        public async Task<IActionResult> Update(CuentasDTO cuenta)
        {
            try
            {
                await _cuentaService.UpdateAsync(cuenta);
                return Ok(cuenta);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cuentaService.DeleteAsync(id);
                return Ok();
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
