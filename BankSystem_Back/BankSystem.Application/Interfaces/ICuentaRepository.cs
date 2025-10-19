using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Interfaces
{
    public interface ICuentaRepository
    {
        Task AddAsync(Cuenta cuenta);
        Task UpdateAsync(Cuenta cuenta);
        Task DeleteAsync(Cuenta cuenta);
        Task<Cuenta> GetByIdAsync(int id);
        Task<IList<Cuenta>> GetAllAsync();

    }
}
