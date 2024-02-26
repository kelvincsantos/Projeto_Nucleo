using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClosedXML.Excel;
using System.Linq;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Numerics;

namespace Nucleo.Base.Transporte
{
    public static class Excel
    {
        
        public static DataTable Importar(DataTable estrutura, string arquivo)
        {
            try
            {
                string[] Letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                XLWorkbook excel = new XLWorkbook(arquivo);
                IXLWorksheet sheet = excel.Worksheets.FirstOrDefault();

                DataTable dt = new DataTable();
                bool ColunasAdicionadas = false;
                for (int i = 2; i < sheet.RowCount() - 1; i++)
                {
                    int index = 0;
                    if (!ColunasAdicionadas)
                    {
                        string conteudo;
                        
                        do
                        {
                            conteudo = string.Empty;

                            conteudo = sheet.Cell(String.Format("{0}{1}", Letras[index], i - 1)).Value.ToString();

                            if (!string.IsNullOrWhiteSpace(conteudo))
                            {
                                dt.Columns.Add(conteudo);
                                index++;
                            }
                        } while (!string.IsNullOrWhiteSpace(conteudo));
                    }

                    DataRow dr = dt.NewRow();
                    for (int j = 0; j <= index; j++)
                    {
                        dr.SetField(j, sheet.Cell(String.Format("{0}{1}", Letras[j], i)).Value.ToString());
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static bool Exportar(DataTable ds)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool CriarPadrao(DataTable dt)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
