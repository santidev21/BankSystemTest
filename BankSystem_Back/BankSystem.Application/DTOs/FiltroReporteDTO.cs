using System.ComponentModel.DataAnnotations;

namespace BankSystem.Application.DTOs
{
    public class FiltroReporteDTO
    {
        [Required]
        public DateTime LimiteInferior { get; set; }

        [Required]
        public DateTime LimiteSuperior { get; set; }

        public int? cuentaId { get; set; }

    }
}
