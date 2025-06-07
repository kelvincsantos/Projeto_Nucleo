using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.API.Core.Aplicacao
{
    public class Entrada
    {
        public Entrada()
        {
            this.Conteudo = string.Empty;
            this.EndPoint = string.Empty;
            this.Headers = new Dictionary<string, string>();
            this.Parametros = new Dictionary<string, string>();
        }

        public Metodo Metodo { get; set; }
        public string Conteudo { get; set; }
        public string EndPoint { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string,string> Parametros { get; set; }



        public string EndPointComParametros()
        {
            string endPoint = EndPoint;
            if (Parametros != null && Parametros.Count > 0)
            {
                string param = string.Empty;

                //foreach (KeyValuePair<string, string> item in e.Parametros)
                //{
                //    if (string.IsNullOrWhiteSpace(param))
                //        param = "&";

                //    param += string.Concat(param, item.Key, "=", item.Value);
                //}

                endPoint = string.Concat(endPoint, param);
            }

            return endPoint;
        }
    }
}
