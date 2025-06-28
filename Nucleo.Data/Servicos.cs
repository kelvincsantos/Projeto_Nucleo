using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public class Servicos
    {
        public Servicos() { }

        public string ID { get; set; }
        public string Classe { get; set; }
        public DateTime? UltimaExecucao { get; set; }
        public int MinutosEspera { get; set; }
    }
}
