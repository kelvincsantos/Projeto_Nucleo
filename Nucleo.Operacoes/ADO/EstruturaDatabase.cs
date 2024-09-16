using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.ADO
{
    public class EstruturaDatabase
    {
        public Nucleo.Base.SQL.SQL Banco { get; set; }

        public EstruturaDatabase(Nucleo.Base.SQL.SQL banco)
        {
            Banco = banco;
        }

        public EstruturaDatabase() { }
    }
}
