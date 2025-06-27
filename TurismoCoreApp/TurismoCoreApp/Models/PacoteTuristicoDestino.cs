namespace TurismoCoreApp.Models
{
    public class PacoteTuristicoDestino
    {
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = null!;

        public int DestinoId { get; set; }
        public Destino? Destino { get; set; }

        public int OrdemVisita { get; set; }
        public int DiasNoDestino { get; set; }
    }
}