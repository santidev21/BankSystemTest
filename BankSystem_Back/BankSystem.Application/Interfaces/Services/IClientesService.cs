using BankSystem.Application.DTOs.Clientes;

namespace BankSystem.Application.Interfaces.Services
{
    public interface IClientesService
    {
        Task AddAsync(CrearClienteDTO cliente);
        Task UpdateAsync(ClienteDTO cliente);
        Task DeleteAsync(int id);
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<IList<ClienteDTO>> GetAllAsync();
    }
}
