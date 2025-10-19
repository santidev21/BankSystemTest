using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        
        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Cliente>>> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente) 
        {
            await _clienteRepository.UpdateAsync(cliente);
            return Ok(cliente);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
