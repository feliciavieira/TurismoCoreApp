using System.ComponentModel.DataAnnotations;

namespace TurismoCoreApp.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = null!;

        public DateTime DataReserva { get; set; } = DateTime.Now;

        [Range(1, 10, ErrorMessage = "Número de pessoas deve ser entre 1 e 10")]
        public int NumeroPessoas { get; set; } = 1;

        public decimal ValorTotal { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}