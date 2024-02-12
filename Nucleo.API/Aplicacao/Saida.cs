using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.API.Aplicacao
{
    public class Saida
    {
        public Saida() 
        {
            this.Conteudo = string.Empty;
            this.Erro = new _Erro();
        }
        public string? Conteudo { get; set; }
        public _Erro Erro { get; set; }

        public partial class _Erro
        {
            public _Erro()
            {
                this.Erro = string.Empty;
                this.excecao = null;
            }

            public string Erro { get; set; }
            public int Codigo { get; set; }

            public Exception? excecao { get; set; }
        }
    }
}
