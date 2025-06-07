using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data.Struct
{
    public class TabelaDB
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public List<ColunaDB> colunas { get; set; }
        private List<RestricaoDB.FK> ChavesEstrangeiras { get; set; }

        public void AdicionarChaves(List<RestricaoDB.FK> chaves)
        {
            if (ChavesEstrangeiras == null)
                ChavesEstrangeiras = new List<RestricaoDB.FK>();

            ChavesEstrangeiras.AddRange(chaves);
        }

        public List<string> ColunasAlteradas()
        {
            throw new NotImplementedException();
        }

        public string Criar()
        {
            string query = string.Empty;

            query = string.Concat("CREATE TABLE ", Nome, "(", Environment.NewLine);

            foreach (ColunaDB coluna in colunas)
            {
                query += string.Concat(coluna.Nome, " ", coluna.Tipo.ToString(), coluna.Precisao);

                if (coluna.isPK) 
                    query += string.Concat(" PRIMARY KEY");

                if (coluna.isNullable && !coluna.isPK) 
                    query += string.Concat(" NULL");
                else 
                    query += string.Concat(" NOT NULL");

                query += Environment.NewLine;
            }


            query += string.Concat(")");
            return query;
        }
    }
}
