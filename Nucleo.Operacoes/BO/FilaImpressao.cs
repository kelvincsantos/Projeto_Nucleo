using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.BO
{
    public class FilaImpressao
    {
        public Nucleo.Base.SQL.SQL banco { get; set; }
        public FilaImpressao() { }
        public FilaImpressao(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }

        public bool Existe(string ID)
        {
            ADO.FilaImpressao DAO = new ADO.FilaImpressao(banco);
            return DAO.Existe(ID);
        }

        public Nucleo.Data.FilaImpressao BuscarPorEtiqueta(string ID) 
        {
            ADO.FilaImpressao DAO = new ADO.FilaImpressao(banco);
            return DAO.BuscarPorEtiqueta(ID);
        }

        public bool Alterar(Data.FilaImpressao fila)
        {
            ADO.FilaImpressao DAO = new ADO.FilaImpressao(banco);
            return DAO.Alterar(fila);
        }
    }
}
