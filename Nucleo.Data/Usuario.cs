using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Data
{
    public class Usuario
    {
        public string ID { get; set; }

        public string Login { get; set; }
        public string Senha { get; set; }
        public bool? Ativo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Email { get; set; }
    }
}
