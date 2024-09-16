using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public class Menu
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string IDMenuPai { get; set; }
        public string Navegacao { get; set; }
        public bool UsuarioPermitido { get; set; }
    }
}
