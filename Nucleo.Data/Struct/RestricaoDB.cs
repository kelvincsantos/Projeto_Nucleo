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
            public TabelaDB TabelaFK { get; set; }

            public string AddRestricao()
            {
                if (Tabela == null)
                    return string.Empty;

                if (TabelaFK == null)
                    return string.Empty;

                return string.Concat("ALTER TABLE ", Tabela.Nome,
                "ADD CONSTRAINT FK_", TabelaFK.Nome, "_", TabelaFK.colunas.FirstOrDefault().Nome,
                    "FOREIGN KEY(", Tabela.colunas.FirstOrDefault().Nome, ")",
                    "REFERENCES ", TabelaFK.Nome, "(", TabelaFK.colunas.FirstOrDefault().Nome, ");");
            }
        }

        public partial class Default
        {
            public string ID { get; set; }

            public TabelaDB tabela { get; set; }

            public List<object> Valores { get; set; }

            public string AddDefault(bool ColunaNova = false)
            {
                if (tabela == null) return string.Empty;

                if (tabela.colunas == null) return string.Empty;

                if (tabela.colunas.Count() == 0) return string.Empty;

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
                    ColunaNova ? "ADD " : "ALTER COLUMN ", tabela.colunas.FirstOrDefault().Nome, ColunaNova ? " DATETIME DEFAULT " : " DEFAULT ", ValorDefault);
            }
        }
    }
}
