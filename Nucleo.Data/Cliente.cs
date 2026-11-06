using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public int Codigo { get; set; }
        public string Documento { get; set; }

        public string Telefone { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public int TipoPessoa { get; set; }

        public Cliente() { }
    }
}
