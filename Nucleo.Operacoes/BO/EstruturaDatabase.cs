using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.BO
{
    public class EstruturaDatabase
    {
        private ADO.EstruturaDatabase DAO { get; set; }

        public EstruturaDatabase()
        {
            DAO = new ADO.EstruturaDatabase();
        }

        public EstruturaDatabase(Nucleo.Base.SQL.SQL banco)
        {
            DAO = new ADO.EstruturaDatabase(banco);
        }

        public void Atualizar()
        {

        }
    }
}
