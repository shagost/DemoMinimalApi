using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public decimal Valor { get; set; }
        [JsonIgnore]
        public decimal Saldo { get; set; }

        public void AtualizaLancamento(decimal saldoAnterior)
        {
            if (TipoLancamentoId == 2 && Valor > 0)
                Valor *= -1;

            if (DataLancamento == new DateTime())
                DataLancamento = DateTime.Now;

            Saldo = saldoAnterior + Valor;
        }
    }
}