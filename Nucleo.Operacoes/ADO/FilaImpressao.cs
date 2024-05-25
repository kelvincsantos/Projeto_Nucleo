using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.ADO
{
    public class FilaImpressao
    {
        public Nucleo.Base.SQL.SQL Banco { get; set; }

        public FilaImpressao() { }
        public FilaImpressao(Nucleo.Base.SQL.SQL banco)
        {
            Banco = banco;
        }

        public bool Inserir(Nucleo.Data.FilaImpressao filaImpressao)
        {
            try
            {
                string Query = "";
                Query += "		INSERT INTO [dbo].[FilaImpressao]							" + Environment.NewLine;
                Query += "		           ([ID]											" + Environment.NewLine;
                Query += "		           ,[Criacao]										" + Environment.NewLine;
                Query += "		           ,[Erro]											" + Environment.NewLine;
                Query += "		           ,[CodigoEtiqueta]								" + Environment.NewLine;
                Query += "		           ,[Impressao]										" + Environment.NewLine;
                Query += "		           ,[Concluido]										" + Environment.NewLine;
                Query += "		           )											" + Environment.NewLine;
                Query += "		     VALUES													" + Environment.NewLine;
                Query += "		           ('" + filaImpressao.ID + "'								" + Environment.NewLine;
                Query += "		           ,CONVERT(DATE, '" + filaImpressao.Criacao + "', 103)								" + Environment.NewLine;
                Query += "		           ,'" + filaImpressao.Erro + "'							" + Environment.NewLine;
                Query += "		           ,'" + filaImpressao.CodigoEtiqueta + "'					" + Environment.NewLine;

                if (filaImpressao.Impressao != null)
                    Query += "		           ,CONVERT(DATE, '" + filaImpressao.Impressao + "', 103)								" + Environment.NewLine;
                else
                    Query += "		           ,NULL 								" + Environment.NewLine;

                if (filaImpressao.Concluido != null)
                    Query += "		           ," + Convert.ToInt16(filaImpressao.Concluido) + "								" + Environment.NewLine;
                else
                    Query += "		           ,NULL 								" + Environment.NewLine;

                Query += "		           )							" + Environment.NewLine;

                return Banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Alterar(Nucleo.Data.FilaImpressao filaImpressao)
        {
            try
            {
                string Query = "";
                Query += "	UPDATE [dbo].[FilaImpressao]								" + Environment.NewLine;
                if (filaImpressao.Impressao != null)
                    Query += "	   SET [Impressao] = CONVERT(DATE, '" + filaImpressao.Impressao + "', 103)						" + Environment.NewLine;
                else
                    Query += "	   SET [Impressao] = NULL						" + Environment.NewLine;

                if (filaImpressao.Concluido != null)
                    Query += "	      ,[Concluido] = " + Convert.ToInt16(filaImpressao.Concluido) + "						" + Environment.NewLine;
                else
                    Query += "	      ,[Concluido] = NULL						" + Environment.NewLine;
                Query += "	      ,[Erro] = '" + filaImpressao.Erro + "'						" + Environment.NewLine;
                Query += "	 WHERE [ID] = '" + filaImpressao.ID + "'							" + Environment.NewLine;

                return Banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Existe(string ID)
        {
            string Query = "SELECT * FROM FILAIMPRESSAO WHERE ID = '" + ID + "'";

            return Banco.Ler(Query).HasRows;
        }

        public bool ExisteEtiqueta(string ID)
        {
            string Query = "SELECT * FROM FILAIMPRESSAO WHERE CODIGOETIQUETA = '" + ID + "'";

            return Banco.Ler(Query).HasRows;
        }
    }
}
