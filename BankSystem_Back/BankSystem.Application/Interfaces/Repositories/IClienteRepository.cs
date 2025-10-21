using BankSystem.Domain.Entities;

namespace BankSystem.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
        Task<Cliente> GetByIdAsync(int id);
        Task<IList<Cliente>> GetAllAsync();
    }
}
