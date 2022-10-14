using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.ViewModels
{
    public class LancamentoCreateViewModel
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int TipoLancamentoId { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}