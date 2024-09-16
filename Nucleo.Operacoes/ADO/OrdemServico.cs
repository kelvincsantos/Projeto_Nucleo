using DocumentFormat.OpenXml.Office.CoverPageProps;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.ADO
{
    public class OrdemServico
    {
        public Nucleo.Base.SQL.SQL banco { get; set; }
        public OrdemServico() { }
        public OrdemServico(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }


        public bool Existe(string ID)
        {
            string Query = "SELECT * FROM OrdemServico WHERE ID = '" + ID + "'";

            return banco.Ler(Query).HasRows;
        }

        public bool ExisteOS(string OS)
        {
            string Query = "SELECT * FROM OrdemServico WHERE OS = '" + OS + "'";

            return banco.Ler(Query).HasRows;
        }

        public bool Deletar(Nucleo.Data.OrdemServico OS)
        {
            try
            {
                string Query = "";
                Query += "	DELETE FROM [dbo].[OrdemServico]													" + Environment.NewLine;
                Query += "	 WHERE [ID] = '" + OS.ID + "'											" + Environment.NewLine;

                return banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Inserir(Nucleo.Data.OrdemServico OS)
        {
            try
            {
                string Query = "";
                Query += "		INSERT INTO [dbo].[OrdemServico]								" + Environment.NewLine;
                Query += "		           ([ID]												" + Environment.NewLine;
                Query += "		           ,[OS]									        	" + Environment.NewLine;
                Query += "		           ,[Criacao]										    " + Environment.NewLine;
                Query += "		           ,[Encerramento])									    " + Environment.NewLine;
                Query += "		     VALUES														" + Environment.NewLine;
                Query += "		           ('" + OS.ID + "'										" + Environment.NewLine;
                Query += "		           ,'" + OS.OS + "'	                                    " + Environment.NewLine;
                Query += "		           ,CONVERT(DATETIME, '" + OS.Criacao + "', 103)	    " + Environment.NewLine;
                Query += "		           ,CONVERT(DATETIME, '" + OS.Encerramento + "', 103))	" + Environment.NewLine;

                return banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Alterar(Nucleo.Data.OrdemServico OS)
        {
            try
            {
                string Query = "";
                Query += "	UPDATE [dbo].[OrdemServico]													" + Environment.NewLine;
                Query += "	   SET [OS] = '" + OS.OS + "' 							" + Environment.NewLine;

                if(OS.Encerramento != null)
                    Query += "	      ,[Encerramento] = CONVERT(DATE, '" + OS.Encerramento + "', 103)						" + Environment.NewLine;

                if(OS.Criacao != null)
                    Query += "	      ,[Criacao] = CONVERT(DATE, '" + OS.Criacao + "', 103)			" + Environment.NewLine;

                Query += "	 WHERE [ID] = '" + OS.ID + "'											" + Environment.NewLine;

                return banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Nucleo.Data.OrdemServico BuscarOS(string OS)
        {
            string Query = "";
            Query += "		select		e.ID								" + Environment.NewLine;
            Query += "			,		e.Criacao					" + Environment.NewLine;
            Query += "			,		e.Encerramento					" + Environment.NewLine;
            Query += "			,		e.OS					" + Environment.NewLine;
            Query += "      from        OrdemServico        as e    " + Environment.NewLine;
            Query += "		where		e.OS = '" + OS +  "'	" + Environment.NewLine;

            SqlDataReader reader = banco.Ler(Query);

            Nucleo.Data.OrdemServico item = new  Data.OrdemServico();

            if (reader == null)
                return item;

            if (!reader.HasRows)
                return item;

            while (reader.Read())
            {
                item.ID = reader.GetString(0);
                item.Criacao = reader.GetDateTime(1);
                item.Encerramento = reader.GetDateTime(2);
                item.OS = reader.GetString(3);
            }

            return item;
        }
    }
}
