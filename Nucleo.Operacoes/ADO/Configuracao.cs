using DocumentFormat.OpenXml.Office2010.Excel;
using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nucleo.Operacoes.ADO
{
    public class Configuracao
    {
        public Nucleo.Base.SQL.SQL Banco { get; set; }

        public Configuracao() { }
        public Configuracao(Nucleo.Base.SQL.SQL banco)
        {
            Banco = banco;
        }

        public bool InserirOuAlterar(PropriedadeConfiguracao e)
        {
            try
            {
                KeyValuePair<string, string> key = new KeyValuePair<string, string>(e.Campo, e.Valor);

                bool sucesso = false;
                if (Existe(e.Campo))
                    sucesso = Alterar(key);
                else
                    sucesso = Inserir(key);

                if (!sucesso)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InserirOuAlterar(Dictionary<string, string> e)
        {
            try
            {
                foreach (KeyValuePair<string, string> key in e)
                {
                    bool sucesso = false;
                    if (Existe(key.Key))
                        sucesso = Alterar(key);
                    else
                        sucesso = Inserir(key);

                    if (!sucesso)
                        return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Existe(string campo)
        {
            string Query = "SELECT 1 FROM Configuracao WHERE campo = '" + campo + "'";

            return Banco.Ler(Query).HasRows;
        }

        public bool Inserir(KeyValuePair<string, string> e)
        {
            try
            {

                string Query = "";
                Query += "		INSERT INTO [dbo].[Configuracao]							" + Environment.NewLine;
                Query += "		           ([ID]											" + Environment.NewLine;
                Query += "		           ,[Campo] 										" + Environment.NewLine;
                Query += "		           ,[Valor]											" + Environment.NewLine;
                Query += "		           )		    									" + Environment.NewLine;
                Query += "		     VALUES													" + Environment.NewLine;
                Query += "		           ('" + Guid.NewGuid() + "'						" + Environment.NewLine;
                Query += "		           ,'" + e.Key + "' 								" + Environment.NewLine;
                Query += "		           ,'" + e.Value + "'	    						" + Environment.NewLine;
                Query += "		           )                    							" + Environment.NewLine;

                return Banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Alterar(KeyValuePair<string, string> e)
        {
            try
            {
                string Query = "";
                Query += "	UPDATE [dbo].[Configuracao]								" + Environment.NewLine;
                Query += "	   SET [Valor] = '" + e.Value + "'						" + Environment.NewLine;
                Query += "	 WHERE [Campo] = '" + e.Key + "'						" + Environment.NewLine;

                return Banco.Executar(Query);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Data.PropriedadeConfiguracao> Buscar()
        {
            List<Data.PropriedadeConfiguracao> lista = new List<Data.PropriedadeConfiguracao>();
            string Query = "SELECT ID, Campo, Valor FROM Configuracao";

            SqlDataReader reader = Banco.Ler(Query);

            if (reader == null)
                return lista;

            if (!reader.HasRows)
                return lista;
            
            while (reader.Read())
            {
                Data.PropriedadeConfiguracao item = new Data.PropriedadeConfiguracao();

                item.ID = reader.GetString(0);
                item.Campo = reader.GetString(1);
                item.Valor = reader.GetString(2);

                lista.Add(item);
            }

            return lista;
        }
    }
}
