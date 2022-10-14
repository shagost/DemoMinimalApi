using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.ViewModels
{
    public class LancamentoUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}