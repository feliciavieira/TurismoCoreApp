using System.ComponentModel.DataAnnotations;

namespace TurismoCoreApp.Models
{
    public class Destino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "País é obrigatório")]
        [MinLength(2, ErrorMessage = "País deve ter pelo menos 2 caracteres")]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        [MinLength(2, ErrorMessage = "Cidade deve ter pelo menos 2 caracteres")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        public DateTime? DeletedAt { get; set; }

        public List<PacoteTuristicoDestino> PacoteTuristicoDestinos { get; set; } = new List<PacoteTuristicoDestino>();

        // Propriedades calculadas
        [Display(Name = "Destino Completo")]
        public string NomeCompleto => $"{Cidade}, {Pais}";

        public string Descricao { get; set; }
    }
}