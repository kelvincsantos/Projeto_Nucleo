using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public class Ticker
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string NomeEmpresa { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
