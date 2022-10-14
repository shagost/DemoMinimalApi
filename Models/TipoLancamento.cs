using System.Text.Json.Serialization;

namespace FluxoCaixa.Models
{
    public class TipoLancamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        [JsonIgnore]
        public ICollection<Lancamento> Lancamento { get; set; }
    }
}