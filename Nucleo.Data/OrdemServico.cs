using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public class OrdemServico
    {
        public string ID { get; set; }
        public string OS { get; set; }
        public DateTime? Criacao { get; set; }
        public DateTime? Encerramento { get; set; }
    }
}
