using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes.BO
{
    public class Etiquetas
    {
        public Nucleo.Base.SQL.SQL banco { get; set; }
        public Etiquetas() { }
        public Etiquetas(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }

        public bool InserirOuAlterar(Nucleo.Data.Etiqueta etiqueta)
        {
            ADO.Etiquetas DAO = new ADO.Etiquetas(banco);
            if (Existe(etiqueta.ID))
                return DAO.Alterar(etiqueta);
            else
                return DAO.Inserir(etiqueta);

        }

        public bool Deletar(Nucleo.Data.Etiqueta etiqueta)
        {
            ADO.Etiquetas DAO = new ADO.Etiquetas(banco);
            if (Existe(etiqueta.ID))
                return DAO.Deletar(etiqueta);

            return true;
        }


        public bool GerarFilaImpressao(Nucleo.Data.Etiqueta etiqueta)
        {
            ADO.FilaImpressao DAO = new ADO.FilaImpressao(banco);

            if (!DAO.ExisteEtiqueta(etiqueta.ID))
                return DAO.Inserir(new Data.FilaImpressao()
                {
                    CodigoEtiqueta = etiqueta.ID,
                    ID = Guid.NewGuid().ToString(),
                    Criacao = DateTime.Now,
                });

            return true;
        }

        public bool Existe(string ID)
        {
            ADO.Etiquetas DAO = new ADO.Etiquetas(banco);
            return DAO.Existe(ID);
        }

        public List<Nucleo.Data.Etiqueta> BuscarPendentesDeImpressao()
        {
            ADO.Etiquetas DAO = new ADO.Etiquetas(banco);
            return DAO.BuscarPendentesDeImpressao();
        }

    }
}
