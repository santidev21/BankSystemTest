using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
