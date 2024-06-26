using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public Nucleo.Data.FilaImpressao BuscarPorEtiqueta(string ID)
        {
            string Query = "SELECT ID, Criacao, Impressao, CodigoEtiqueta, Concluido, Erro FROM FILAIMPRESSAO WHERE CODIGOETIQUETA = '" + ID + "'";

            SqlDataReader reader = Banco.Ler(Query);

            Nucleo.Data.FilaImpressao item = new Nucleo.Data.FilaImpressao();
            while (reader.Read())
            {
                item = new Nucleo.Data.FilaImpressao();

                item.ID = reader.GetString(0);
                item.Criacao = reader.GetDateTime(1);
                item.Impressao = reader.GetValue(2) == DBNull.Value ? null : reader.GetDateTime(2);
                item.CodigoEtiqueta = reader.GetString(3);
                item.Concluido = reader.GetValue(4) == DBNull.Value ? false: reader.GetBoolean(4);
                item.Erro = reader.GetString(5);
            }

            return item;
        }
    }
}
