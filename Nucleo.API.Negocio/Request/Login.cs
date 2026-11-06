using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.API.Negocio.Request
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string IP { get; set; }

        public DateTime Tentativa { get; set; }

    }
}
