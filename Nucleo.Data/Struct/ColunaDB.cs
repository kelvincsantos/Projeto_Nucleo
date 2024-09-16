using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data.Struct
{
    public class ColunaDB
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public TipoColuna Tipo { get; set; }

        public bool isPK { get; set; }
        public bool isNullable { get; set; }

        public List<object> valoresDefault { get; set; }
        public enum TipoColuna
        {
            Integer = 0,
            Varchar = 1,
            Decimal = 2,
            Data = 3,
            Bit = 4,

        }
    }
}
