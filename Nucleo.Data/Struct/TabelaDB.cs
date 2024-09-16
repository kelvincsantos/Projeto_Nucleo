using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data.Struct
{
    public class TabelaDB
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public List<ColunaDB> colunas { get; set; }
        public List<RestricaoDB.FK> ChavesEstrangeiras { get; set; }
    }
}
