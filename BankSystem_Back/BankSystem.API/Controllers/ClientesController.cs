using BankSystem.Application.DTOs.Clientes;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IClientesService _clientesService;
        
        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ClienteDTO>>> GetAll()
        {
            try
            {
                var clientes = await _clientesService.GetAllAsync();
                return Ok(clientes);
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
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            try
            {
                var cliente = await _clientesService.GetByIdAsync(id);
                if (cliente == null) return NotFound();
                return Ok(cliente);
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
        public async Task<IActionResult> Create(CrearClienteDTO cliente)
        {
            try
            {
                await _clientesService.AddAsync(cliente);
                return Ok(cliente);
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
        public async Task<IActionResult> Update(ClienteDTO cliente) 
        {
            try
            {
                await _clientesService.UpdateAsync(cliente);
                return Ok(cliente);
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
                await _clientesService.DeleteAsync(id);
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
