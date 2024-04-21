using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Data
{
    public class FilaImpressao
    {
        public string ID { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? Impressao { get; set; }
        public string CodigoEtiqueta { get; set; }
        public string? Erro { get; set; }
        public bool? Concluido { get; set; }

    }
}
