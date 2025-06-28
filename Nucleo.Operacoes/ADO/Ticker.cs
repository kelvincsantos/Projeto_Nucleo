using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Nucleo.Data;

namespace Nucleo.Operacoes.ADO
{
    public class Ticker
    {

        public Nucleo.Base.SQL.SQL banco { get; set; }
        public Ticker() { }
        public Ticker(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }

        public List<Data.Ticker> BuscarTodos()
        {
            List <Data.Ticker > tickers = null;

            string Query = "";
            Query += "		select		T.ID							" + Environment.NewLine;
            Query += "			,		T.Codigo		    			" + Environment.NewLine;
            Query += "			,		T.NomeEmpresa					" + Environment.NewLine;
            Query += "			,		T.DataCadastro					" + Environment.NewLine;
            Query += "			,		T.DataAtualizacao				" + Environment.NewLine;
            Query += "      from        Tickers        as T             " + Environment.NewLine;

            SqlDataReader reader = banco.Ler(Query);
           
            if (reader == null)
                return tickers;

            if (!reader.HasRows)
                return tickers;

            tickers = new List<Data.Ticker>();
            Data.Ticker item = new Data.Ticker();

            while (reader.Read())
            {
                item = new Data.Ticker();
                item.Id = reader.GetString(0);
                item.Codigo = reader.GetString(1);
                item.NomeEmpresa = reader.GetString(2);
                item.DataCadastro = reader.GetDateTime(3);
                item.DataAtualizacao = string.IsNullOrWhiteSpace(reader.GetString(4)) ? null : reader.GetDateTime(4);

                tickers.Add(item);
            }

            return tickers;
        }
    }
}
