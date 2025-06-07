using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nucleo.Data.Struct.RestricaoDB;

namespace Nucleo.Data.Struct
{
    public class RestricaoDB
    {
        public partial class FK
        {
            public string ID { get; set; }
            public TabelaDB Tabela { get; set; }
            public ColunaDB Coluna { get; set; }
            public TabelaDB TabelaFK { get; set; }
            public ColunaDB ColunaFK { get; set; }

            public string Add()
            {
                if (Tabela == null)
                    return string.Empty;

                if (TabelaFK == null)
                    return string.Empty;

                if (Coluna == null)
                    return string.Empty;

                if (ColunaFK == null)
                    return string.Empty;


                return string.Concat("ALTER TABLE ", Tabela.Nome,
                "ADD CONSTRAINT FK_", TabelaFK.Nome, "_", ColunaFK.Nome,
                    "FOREIGN KEY(", Coluna.Nome, ")",
                    "REFERENCES ", TabelaFK.Nome, "(", ColunaFK.Nome, ");");
            }

            public List<string> AlteracaoDaTabela()
            {
                throw new NotImplementedException();
            }

            public string NaCriacaoDaTabela()
            {
                return string.Concat("CONSTRAINT FK_", TabelaFK.Nome, "_", ColunaFK.Nome
                    , " FOREIGN KEY (", Coluna.Nome, ") REFERENCES "
                    , TabelaFK.Nome, "(", ColunaFK.Nome, ")");
            }
        }

        public partial class Default
        {
            public string ID { get; set; }

            public TabelaDB tabela { get; set; }
            public ColunaDB coluna { get; set; }
            public List<object> Valores { get; set; }

            public string Add(bool ColunaNova = false)
            {
                if (tabela == null) return string.Empty;

                if (coluna == null) return string.Empty;

                if (Valores == null) return string.Empty;

                string ValorDefault = string.Empty;
                if (Valores.Count() > 1)
                {
                    foreach (object o in Valores)
                    {
                        string item = string.Empty;

                        if(o.GetType() == typeof(string))
                            item += string.Concat("\"", o, "\"");

                        if (string.IsNullOrWhiteSpace(ValorDefault))
                            ValorDefault += item;
                        else
                            ValorDefault += ", " + item;
                    }

                    ValorDefault = "(" + ValorDefault + ")";
                }
                else
                    ValorDefault = Valores.FirstOrDefault().ToString();
                
                return string.Concat("ALTER TABLE ", tabela.Nome,
                    ColunaNova ? "ADD " : "ALTER COLUMN ", coluna.Nome, ColunaNova ? " DATETIME DEFAULT " : " DEFAULT ", ValorDefault);
            }
        }

        public partial class Indices
        {
            public string ID { get; set; }

            public TabelaDB tabela { get; set; }
            public List<ColunaDB> colunas { get; set; }

            public string Add()
            {
                string nomeIndex = string.Empty;

                if (tabela == null)
                    return string.Empty;

                if (colunas == null)
                    return string.Empty;

                if (colunas.Count == 0)
                    return string.Empty;

                nomeIndex = string.Concat("IDX_", tabela.Nome.ToUpper(), "_");

                if (colunas.Count == 1)
                    nomeIndex = string.Concat(nomeIndex, colunas.FirstOrDefault().Nome);
                else
                    foreach (ColunaDB coluna in colunas)
                        nomeIndex = string.Concat(nomeIndex, coluna.Nome.Substring(0, 3));
                    
                string retorno = string.Concat("CREATE INDEX ", nomeIndex, " ON ", tabela.Nome, "(");

                bool first = true;
                foreach (ColunaDB coluna in colunas)
                {
                    if (first)
                    {
                        first = false;
                        retorno = string.Concat(retorno, coluna.Nome);
                    }
                    else
                        retorno = string.Concat(retorno, ",", coluna.Nome);
                }

                return string.Concat(retorno, ");");
            }

            public List<string> Criar()
            {
                throw new NotImplementedException();
            }
        }
    }
}
