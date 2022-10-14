using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.ViewModels
{
    public class ConsolidadoConsultaViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }
    }
}