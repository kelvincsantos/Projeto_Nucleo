using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.BO
{
    public class OrdemServico
    {
        private ADO.OrdemServico DAO;
        public Nucleo.Base.SQL.SQL banco { get; set; }
        public OrdemServico() { }
        public OrdemServico(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
            this.DAO = new ADO.OrdemServico(banco);
        }

        public bool Existe(string ID)
        {
            return DAO.Existe(ID);
        }

        public bool ExisteOS(string OS)
        {
            return DAO.ExisteOS(OS);
        }

        public bool InserirOuAlterar(Nucleo.Data.OrdemServico OS)
        {
            if (Existe(OS.ID))
                return DAO.Alterar(OS);
            else
                return DAO.Inserir(OS);

        }

        public bool Deletar(Nucleo.Data.OrdemServico OS)
        {
            if (Existe(OS.ID))
                return DAO.Deletar(OS);

            return true;
        }

        public Nucleo.Data.OrdemServico BuscarOS(string OS)
        {
            return DAO.BuscarOS(OS);
        }

        public List<Nucleo.Data.Etiqueta> BuscarEtiquetas(Nucleo.Data.OrdemServico OS)
        {
            return new Nucleo.Operacoes.ADO.Etiquetas(banco).BuscarPorOS(OS.ID);
        }
    }
}
