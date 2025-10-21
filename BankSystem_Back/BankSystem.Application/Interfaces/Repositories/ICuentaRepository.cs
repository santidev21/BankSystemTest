using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Interfaces.Repositories
{
    public interface ICuentaRepository
    {
        Task AddAsync(CrearCuentaDTO cuenta);
        Task UpdateAsync(CuentasDTO cuenta);
        Task DeleteAsync(int id);
        Task<CuentasDTO> GetByIdAsync(int id);
        Task<IList<CuentasDTO>> GetAllAsync();
        Task<int> GetBalanceAsync(int id);

    }
}
