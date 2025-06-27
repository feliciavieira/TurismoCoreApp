using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoCoreApp.Services;

namespace TurismoCoreApp.Pages
{
    public class CalculationDemoModel : PageModel
    {
        [BindProperty]
        public decimal PrecoPacote { get; set; }

        [BindProperty]
        public int NumeroPessoas { get; set; }

        public ResultadoCalculo? Resultado { get; set; }

        public List<string> Logs { get; set; } = new();

        public void OnGet()
        {
            Logs = CalculationService.GetMemoryLogs();
        }

        public void OnPost()
        {
            // Calcula valor total
            var valorTotal = CalculationService.CalcularValorTotal(PrecoPacote, NumeroPessoas);
            CalculationService.LogOperacao?.Invoke($"Cálculo valor total: {PrecoPacote} x {NumeroPessoas} = {valorTotal}");

            // Aplica desconto
            var valorComDesconto = CalculationService.AplicarDesconto10(valorTotal);
            CalculationService.LogOperacao?.Invoke($"Aplicado desconto de 10%: {valorTotal} -> {valorComDesconto}");

            Resultado = new ResultadoCalculo
            {
                ValorTotal = valorTotal,
                ValorComDesconto = valorComDesconto
            };

            Logs = CalculationService.GetMemoryLogs();
        }

        public class ResultadoCalculo
        {
            public decimal ValorTotal { get; set; }
            public decimal ValorComDesconto { get; set; }
        }
    }
}
