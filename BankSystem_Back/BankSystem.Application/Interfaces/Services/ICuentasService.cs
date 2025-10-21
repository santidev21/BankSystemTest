using BankSystem.Application.DTOs.Cuentas;

namespace BankSystem.Application.Interfaces.Services
{
    public interface ICuentasService
    {
        Task AddAsync(CrearCuentaDTO cuenta);
        Task UpdateAsync(CuentasDTO cuenta);
        Task DeleteAsync(int id);
        Task<CuentasDTO> GetByIdAsync(int id);
        Task<IList<CuentasDTO>> GetAllAsync();
    }
}
