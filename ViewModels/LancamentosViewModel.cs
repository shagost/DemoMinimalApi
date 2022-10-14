using FluxoCaixa.Models;

namespace FluxoCaixa.ViewModels
{
    public class LancamentosViewModel
    {
        public DateTime DataLancamento { get; set; }
        public string Descricao { get; set; }
        public int LancamentoId { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }

        public static List<LancamentosViewModel> ObterViewModel(List<Lancamento> lancamentos)
        {
            var lancamentosVM = new List<LancamentosViewModel>();
            lancamentos.ForEach(x =>
                lancamentosVM.Add(
                    new LancamentosViewModel
                    {
                        DataLancamento = x.DataLancamento,
                        Descricao = x.Descricao,
                        LancamentoId = x.Id,
                        Valor = x.Valor,
                        Tipo = x.TipoLancamento.Sigla,
                    }
                )
            );

            return lancamentosVM;
        }
    }
}