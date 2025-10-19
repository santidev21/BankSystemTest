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
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AppDbContext _context;
        public CuentaRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Cuenta>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cuenta> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }
    }
}
