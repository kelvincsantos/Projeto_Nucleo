using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Nucleo.Data;

namespace Nucleo.Service.Comum
{
    public interface IBaseServico
    {
        public Data.Servicos Servicos { get; set; }
        public void Iniciar();
        internal void Executar();
        internal DateTime UltimaExecucao();
        internal bool PodeExecutarNovamente();
    }
}
