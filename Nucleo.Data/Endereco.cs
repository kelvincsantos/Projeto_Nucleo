using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public class Endereco
    {
        public Endereco() { }

        public int ID { get; set; }

        public bool? Principal { get; set; }

        public string EnderecoCompleto()
        {
            return string.Empty;
        }

    }
}
