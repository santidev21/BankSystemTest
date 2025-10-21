using BankSystem.Domain.Entities;

namespace BankSystem.Application.Interfaces.Repositories
{
    public interface ICuentaRepository
    {
        Task AddAsync(Cuenta cuenta);
        Task UpdateAsync(Cuenta cuenta);
        Task DeleteAsync(Cuenta id);
        Task<Cuenta> GetByIdAsync(int id);
        Task<IList<Cuenta>> GetAllAsync();
        Task<int> GetBalanceAsync(int id);

    }
}
