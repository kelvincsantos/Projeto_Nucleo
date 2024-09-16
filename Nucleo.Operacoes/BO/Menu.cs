using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.BO
{
    public class Menu
    {
        public Nucleo.Base.SQL.SQL banco { get; set; }

        private ADO.Menu ADO;

        public Menu() 
        {
            ADO = new ADO.Menu();
        }
        public Menu(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
            ADO = new ADO.Menu(Banco);
        }

        public List<Data.Menu> CarregarMenus(Data.Menu? menu)
        {
            return ADO.BuscarMenus(menu);
        }
    }
}
