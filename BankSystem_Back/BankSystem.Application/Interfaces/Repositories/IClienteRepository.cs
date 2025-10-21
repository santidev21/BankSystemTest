using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
        Task<Cliente> GetByIdAsync(int id);
        Task<IList<Cliente>> GetAllAsync();
    }
}
