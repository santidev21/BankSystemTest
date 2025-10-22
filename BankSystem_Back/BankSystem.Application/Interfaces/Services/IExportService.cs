using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;

namespace BankSystem.Application.Interfaces.Services
{
    public interface IExportService
    {
        Task<byte[]> ExportarMovimientos(FiltroReporteDTO filtro);
    }
}
