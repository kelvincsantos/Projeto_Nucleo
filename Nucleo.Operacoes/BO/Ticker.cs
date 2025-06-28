using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.BO
{
    public class Ticker
    {
        private ADO.Ticker DAO;
        public Nucleo.Base.SQL.SQL banco { get; set; }
        public Ticker() { }
        public Ticker(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
            this.DAO = new ADO.Ticker(banco);
        }

        public List<Data.Ticker> BuscarTodos()
        {
            return DAO.BuscarTodos();
        }
    }
}
