using FluxoCaixa.Models;

namespace FluxoCaixa.ViewModels
{
    public class ConsolidadoViewModel
    {
        public DateTime Data { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoFinal { get; set; }
        public List<LancamentosViewModel> Lancamentos { get; set; }

        public ConsolidadoViewModel(decimal saldoAnterior, decimal saldoFinal, List<Lancamento> lancamentos)
        {
            Lancamentos = new List<LancamentosViewModel>();
            Data = DateTime.Now;
            SaldoAnterior = saldoAnterior;
            SaldoFinal = saldoFinal;

            Lancamentos = LancamentosViewModel.ObterViewModel(lancamentos);
        }
    }
}