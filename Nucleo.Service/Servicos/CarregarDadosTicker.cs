using Nucleo.Service.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Service.Servicos
{
    public class CarregarDadosTicker : IBaseServico
    {
        public int MinutosEspera { get => 1440; }
        public string ID { get; set; }

        public void Iniciar()
        {
            if (PodeExecutarNovamente())
                Executar();
        }

        public bool PodeExecutarNovamente()
        {
            DateTime Execucao = UltimaExecucao();

            Execucao.AddMinutes(MinutosEspera);

            return Execucao <= DateTime.Now;
        }

        public DateTime UltimaExecucao()
        {
            throw new NotImplementedException();
        }

        public void Executar()
        {
            throw new NotImplementedException();
        }
    }
}
