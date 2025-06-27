using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Service.Comum
{
    public interface IBaseServico
    {
        public int MinutosEspera { get; }
        public string  ID { get; set; }
        public void Iniciar();
        internal void Executar();
        internal DateTime UltimaExecucao();
        internal bool PodeExecutarNovamente();
    }
}
