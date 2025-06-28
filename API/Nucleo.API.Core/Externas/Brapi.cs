using Nucleo.API.Core.Aplicacao;
using Nucleo.Base.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Nucleo.API.Core.Externas
{
    public class Brapi
    {
        private const string token = "5Kq3R9kpH37sTFoUDHAgG2";

        private Interface API;
        public Brapi()
        {
            this.API = new Interface("https://brapi.dev/api");
        }

        public Retornos.Brapi.BuscarTicker? BuscarTicker(string Ticker)
        {
            try
            {
                Entrada e = new Entrada()
                {
                    Metodo = Metodo.GET,
                    EndPoint = "/quote/" + Ticker,
                };

                e.Headers.Add("Authorization", string.Concat("Bearer ", token));

                Saida? retorno = API.CallAsync_HTTPClient(e).Result;

                if (retorno == null)
                    return null;

                if (retorno.sucesso)
                {
                    Retornos.Brapi.BuscarTicker ret = new Conversor.Json<Retornos.Brapi.BuscarTicker>().Deserializar(retorno.Conteudo);

                    return ret;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
