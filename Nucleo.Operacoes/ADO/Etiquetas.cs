using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.ADO
{
    public class Etiquetas
    {
        public Nucleo.Base.SQL.SQL banco { get; set; }
        public Etiquetas() { }
        public Etiquetas(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }

        public bool Inserir(Nucleo.Data.Etiqueta etiqueta)
        {
            try
            {
                string Query = "";
                Query += "		INSERT INTO [dbo].[Etiquetas]										" + Environment.NewLine;
                Query += "		           ([ID]													" + Environment.NewLine;
                Query += "		           ,[DataCalibracao]										" + Environment.NewLine;
                Query += "		           ,[ProximaCalibracao]										" + Environment.NewLine;
                Query += "		           ,[NumeroCertificado]										" + Environment.NewLine;
                Query += "		           ,[DiretorioLaudo]										" + Environment.NewLine;
                Query += "		           ,[NumeroIdentificacao])									" + Environment.NewLine;
                Query += "		     VALUES															" + Environment.NewLine;
                Query += "		           ('" + etiqueta.ID + "'										" + Environment.NewLine;
                Query += "		           ,CONVERT(DATE, '" + etiqueta.DataCalibracao + "', 103)	" + Environment.NewLine;
                Query += "		           ,CONVERT(DATE, '" + etiqueta.ProximaCalibracao + "', 103)	" + Environment.NewLine;
                Query += "		           ,'" + etiqueta.NumeroCertificado + "'					" + Environment.NewLine;
                Query += "		           ,'" + etiqueta.DiretorioLaudo + "'						" + Environment.NewLine;
                Query += "		           ,'" + etiqueta.NumeroIdentificacao + "')					" + Environment.NewLine;

                return banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Alterar(Nucleo.Data.Etiqueta etiqueta)
        {
            try
            {
                string Query = "";
                Query += "	UPDATE [dbo].[Etiquetas]													" + Environment.NewLine;
                Query += "	   SET [DataCalibracao] = CONVERT(DATE, '" + etiqueta.DataCalibracao + "', 103)							" + Environment.NewLine;
                Query += "	      ,[ProximaCalibracao] = CONVERT(DATE, '" + etiqueta.ProximaCalibracao + "', 103)						" + Environment.NewLine;
                Query += "	      ,[NumeroCertificado] = '" + etiqueta.NumeroCertificado + "'				" + Environment.NewLine;
                Query += "	      ,[DiretorioLaudo] = '" + etiqueta.DiretorioLaudo + "'					" + Environment.NewLine;
                Query += "	      ,[NumeroIdentificacao] = '" + etiqueta.NumeroIdentificacao + "'			" + Environment.NewLine;
                Query += "	 WHERE [ID] = '" + etiqueta.ID + "'											" + Environment.NewLine;

                return banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Deletar(Nucleo.Data.Etiqueta etiqueta)
        {
            try
            {
                string Query = "";
                Query += "	DELETE FROM [dbo].[Etiquetas]													" + Environment.NewLine;
                Query += "	 WHERE [ID] = '" + etiqueta.ID + "'											" + Environment.NewLine;

                return banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Existe(string ID)
        {
            string Query = "SELECT * FROM ETIQUETAS WHERE ID = '" + ID + "'";

            return banco.Ler(Query).HasRows;
        }

        public List<Nucleo.Data.Etiqueta> BuscarPendentesDeImpressao()
        {
            string Query = "";
            Query += "		select		e.ID								" + Environment.NewLine;
            Query += "			,		e.DataCalibracao					" + Environment.NewLine;
            Query += "			,		e.ProximaCalibracao					" + Environment.NewLine;
            Query += "			,		e.NumeroCertificado					" + Environment.NewLine;
            Query += "			,		e.DiretorioLaudo					" + Environment.NewLine;
            Query += "			,		e.NumeroIdentificacao				" + Environment.NewLine;
            Query += "		from		Etiquetas		as e				" + Environment.NewLine;
            Query += "		 left join	FilaImpressao	as f				" + Environment.NewLine;
            Query += "			on		e.ID = f.CodigoEtiqueta				" + Environment.NewLine;
            Query += "		where		Concluido is null or Concluido = 0	" + Environment.NewLine;

            SqlDataReader reader = banco.Ler(Query);

            List<Nucleo.Data.Etiqueta> lista = new List<Data.Etiqueta>();

            if (reader == null)
                return lista;

            if (!reader.HasRows)
                return lista;

            while (reader.Read())
            {
                Nucleo.Data.Etiqueta item = new Data.Etiqueta();

                item.ID = reader.GetString(0);
                item.DataCalibracao = reader.GetDateTime(1);
                item.ProximaCalibracao = reader.GetDateTime(2);
                item.NumeroCertificado = reader.GetString(3);
                item.DiretorioLaudo = reader.GetString(4);
                item.NumeroIdentificacao = reader.GetString(5);

                lista.Add(item);
            }

            return lista;
        }
    }
}
