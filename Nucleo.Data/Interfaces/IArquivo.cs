using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data.Interfaces
{
    public interface IArquivo
    {
        public string Diretorio();
        public List<string> ConteudoLinhas();

        public string Conteudo();
    }
}
