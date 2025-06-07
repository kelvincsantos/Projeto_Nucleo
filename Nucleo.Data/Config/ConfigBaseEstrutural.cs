using Nucleo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data.Config
{
    public class ConfigBaseEstrutural
    {
        public const string ArquivoIda = "Config\\Export.txt";
        public const string ArquivoVolta = "Config\\Import.txt";

        public int TempoEspera { get; set; }

        public DadosConexao Principal { get; set; }

        public List<DadosConexao> Locais { get; set; }

        public partial class DadosConexao
        {
            public string Servidor { get; set; }
            public string Banco { get; set; }
            public string Senha { get; set; }
            public string Usuario { get; set; }

        }
    }
}
