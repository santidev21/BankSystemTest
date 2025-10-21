using BankSystem.Application.DTOs.Clientes;
using BankSystem.Application.Interfaces.Services;
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
            var clientes = await _clientesService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var cliente = await _clientesService.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearClienteDTO cliente)
        {
            await _clientesService.AddAsync(cliente);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClienteDTO cliente) 
        {
            await _clientesService.UpdateAsync(cliente);
            return Ok(cliente);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientesService.DeleteAsync(id);
            return Ok();
        }
    }
}
