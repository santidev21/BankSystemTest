using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Application.Interfaces.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Services
{
    public class ExportService : IExportService
    {
        private IMovimientoRepository _movimientoRepository;
        public ExportService(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        public async Task<byte[]> ExportarMovimientos(FiltroReporteDTO filtro)
        {
            var movimientos = await _movimientoRepository.GetByRangoFechaAsync(filtro.LimiteInferior, filtro.LimiteSuperior, filtro.cuentaId);
            var movimientosDto = movimientos.Select(mov => new MovimientosDTO
            {
                MovimientoId = mov.MovimientoId,
                CuentaId = mov.Cuenta.CuentaId,
                Fecha = mov.Fecha,
                NombreCliente = mov.Cuenta.Cliente.Nombre,
                NumeroCuenta = mov.Cuenta.NumeroCuenta,
                TipoCuenta = mov.Cuenta.Tipo,
                SaldoInicial = mov.Cuenta.SaldoInicial,
                Estado = mov.Cuenta.Estado,
                Movimiento = mov.Valor,
                SaldoDisponible = mov.Saldo,
                TipoMovimiento = mov.Tipo
            }).ToList();

            var documento = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(10);
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1); // Id
                            columns.RelativeColumn(2); // Fecha
                            columns.RelativeColumn(3); // Nombre
                            columns.RelativeColumn(2); // Tipo
                            columns.RelativeColumn(2); // Cuenta
                            columns.RelativeColumn(2); // Saldo
                            columns.RelativeColumn(2); // TipoMov
                            columns.RelativeColumn(2); // Valor
                            columns.RelativeColumn(2); // Disponible
                            columns.RelativeColumn(1); // Estado
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Id");
                            header.Cell().Element(CellStyle).Text("Fecha");
                            header.Cell().Element(CellStyle).Text("Nombre");
                            header.Cell().Element(CellStyle).Text("Tipo");
                            header.Cell().Element(CellStyle).Text("Cuenta");
                            header.Cell().Element(CellStyle).Text("Saldo");
                            header.Cell().Element(CellStyle).Text("TipoMov");
                            header.Cell().Element(CellStyle).Text("Valor");
                            header.Cell().Element(CellStyle).Text("Disponible");
                            header.Cell().Element(CellStyle).Text("Estado");
                        });

                        foreach (var m in movimientosDto)
                        {
                            table.Cell().Element(CellStyle).Text(m.MovimientoId.ToString());
                            table.Cell().Element(CellStyle).Text(m.Fecha.ToString("yyyy-MM-dd"));
                            table.Cell().Element(CellStyle).Text(m.NombreCliente);
                            table.Cell().Element(CellStyle).Text(m.TipoCuenta);
                            table.Cell().Element(CellStyle).Text(m.NumeroCuenta.ToString());
                            table.Cell().Element(CellStyle).Text(m.SaldoInicial.ToString("C"));
                            table.Cell().Element(CellStyle).Text(m.TipoMovimiento);
                            table.Cell().Element(CellStyle).Text(m.Movimiento.ToString("C"));
                            table.Cell().Element(CellStyle).Text(m.SaldoDisponible.ToString("C"));
                            table.Cell().Element(CellStyle).Text(m.Estado ? "Activo" : "Inactivo");
                        }
                    });
                });
            });

            return documento.GeneratePdf();

        }

        static IContainer CellStyle(IContainer container) =>
            container.Padding(2).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);

    }
}
