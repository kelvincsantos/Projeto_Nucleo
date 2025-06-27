using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.API.Core.Externas
{
    public class Brapi
    {

        public Brapi() { }

        public Retornos.Brapi.BuscarTicker BuscarTicker(string Ticker)
        {
            return new Retornos.Brapi.BuscarTicker();
        }
    }
}
