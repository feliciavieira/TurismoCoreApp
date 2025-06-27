namespace TurismoCoreApp.Services
{
    // Delegate personalizado para cálculo de descontos
    public delegate decimal CalculateDelegate(decimal valor);

    public static class CalculationService
    {
        // Delegate para aplicar desconto de 10%
        public static CalculateDelegate AplicarDesconto10 = (valor) => valor * 0.9m;

        // Func para calcular valor total da reserva (preço do pacote * número de pessoas)
        public static Func<decimal, int, decimal> CalcularValorTotal = (precoPacote, numeroPessoas) => precoPacote * numeroPessoas;

        // Multicast delegate para logs
        public static Action<string> LogOperacao;

        static CalculationService()
        {
            LogOperacao += LogToConsole;
            LogOperacao += LogToFile;
            LogOperacao += LogToMemory;
        }

        private static void LogToConsole(string message)
        {
            Console.WriteLine($"[CONSOLE] {DateTime.Now}: {message}");
        }

        private static void LogToFile(string message)
        {
            try
            {
                var logPath = Path.Combine("wwwroot", "logs", "sistema.log");
                Directory.CreateDirectory(Path.GetDirectoryName(logPath));
                File.AppendAllText(logPath, $"[FILE] {DateTime.Now}: {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo: {ex.Message}");
            }
        }

        private static List<string> _memoryLogs = new List<string>();
        private static void LogToMemory(string message)
        {
            _memoryLogs.Add($"[MEMORY] {DateTime.Now}: {message}");
            if (_memoryLogs.Count > 100) // Limitar a 100 logs
            {
                _memoryLogs.RemoveAt(0);
            }
        }

        public static List<string> GetMemoryLogs() => _memoryLogs.ToList();
    }
}