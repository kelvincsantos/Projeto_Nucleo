using Nucleo.Data.Struct;
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

        internal List<TabelaDB> BuscarTabelasNovas()
        {
            throw new NotImplementedException();
        }

        internal List<RestricaoDB.FK> BuscarChavesPorTabela(TabelaDB tabela)
        {
            throw new NotImplementedException();
        }

        internal List<TabelaDB> BuscarTabelasAlteradas()
        {
            throw new NotImplementedException();
        }

        internal List<RestricaoDB.FK> BuscarChavesAlteradas()
        {
            throw new NotImplementedException();
        }

        internal List<RestricaoDB.Indices> BuscarIndicesNovos()
        {
            throw new NotImplementedException();
        }
    }
}
