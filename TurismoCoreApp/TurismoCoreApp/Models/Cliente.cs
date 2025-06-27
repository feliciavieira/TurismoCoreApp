using System.ComponentModel.DataAnnotations;

namespace TurismoCoreApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
