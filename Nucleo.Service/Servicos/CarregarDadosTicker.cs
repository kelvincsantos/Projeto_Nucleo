using Nucleo.Service.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Nucleo.Data;
using eAPI = Nucleo.API.Core.Externas;
using BO = Nucleo.Operacoes.BO;

namespace Nucleo.Service.Servicos
{
    public class CarregarDadosTicker : IBaseServico
    {
        public Data.Servicos Servicos { get; set; }

        private BO.Ticker BO;
        public CarregarDadosTicker(Data.Servicos servicos) 
        {
            this.Servicos = servicos;
            BO = new BO.Ticker();
        }

        public void Iniciar()
        {
            if (PodeExecutarNovamente())
                Executar();
        }

        public bool PodeExecutarNovamente()
        {
            DateTime Execucao = UltimaExecucao();

            Execucao.AddMinutes(Servicos.MinutosEspera);

            return Execucao <= DateTime.Now;
        }

        public DateTime UltimaExecucao()
        {
            return Servicos.UltimaExecucao.GetValueOrDefault(DateTime.MinValue);
        }

        public void Executar()
        {
            List<Data.Ticker> tickers = BO.BuscarTodos();

            foreach (Data.Ticker t in tickers)
            {
                eAPI.Retornos.Brapi.BuscarTicker ticker = BuscarNaBrapi(t.Codigo);

            }
        }

        private eAPI.Retornos.Brapi.BuscarTicker BuscarNaBrapi(string ticker)
        {
            return new eAPI.Brapi().BuscarTicker(ticker);
        }
    }
}
