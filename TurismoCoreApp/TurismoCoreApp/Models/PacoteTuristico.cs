using System.ComponentModel.DataAnnotations;

namespace TurismoCoreApp.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [MinLength(5, ErrorMessage = "Título deve ter pelo menos 5 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de início é obrigatória")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Data de fim é obrigatória")]
        public DateTime DataFim { get; set; }

        [Range(1, 100, ErrorMessage = "Capacidade deve ser entre 1 e 100")]
        public int CapacidadeMaxima { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public DateTime? DeletedAt { get; set; }

        public List<PacoteTuristicoDestino> PacoteTuristicoDestinos { get; set; } = new List<PacoteTuristicoDestino>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Propriedades calculadas
        public int VagasDisponiveis => CapacidadeMaxima - Reservas.Count(r => r.DeletedAt == null);
        public bool TemVagasDisponiveis => VagasDisponiveis > 0;
        public bool EstaDisponivel => DataInicio > DateTime.Now && TemVagasDisponiveis;

        // Evento para limite de capacidade
        public event Action<string> CapacityReached;

        public void VerificarCapacidade()
        {
            if (VagasDisponiveis <= 0)
            {
                CapacityReached?.Invoke($"Pacote '{Titulo}' atingiu capacidade máxima!");
            }
        }
    }
}