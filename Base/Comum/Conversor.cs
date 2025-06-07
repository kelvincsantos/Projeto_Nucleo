using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Reflection;
using System.Text.Json;
namespace Nucleo.Base.Comum
{
    public static class Conversor
    {

        public static Bitmap BytesToBitmap(byte[] e)
        {
            using (var ms = new MemoryStream(e))
            {
                return new Bitmap(ms);
            }
        }

        public static List<T> DataTableToList<T>(DataTable dataTable) where T : new()
        {
            List<T> listObjeto = new List<T>();

            foreach (DataRow item in dataTable.Rows)
            {
                T objeto = new T();

                foreach (PropertyInfo propriedade in typeof(T).GetProperties().ToList())
                {
                    if (propriedade.CanWrite)
                    {
                        DataColumn coluna = item.Table.Columns[propriedade.Name];
                        if (coluna != null)
                        {
                            object value = item[coluna];
                            propriedade.SetValue(objeto, value, null);
                        }
                    }
                }

                listObjeto.Add(objeto);
            }

            return listObjeto;
        }

        public static DataTable ToDataTable<T>(T objeto)
        {
            DataTable tbl = new DataTable();
            DataRow dataRow = tbl.NewRow();
            foreach (var propriedade in typeof(T).GetProperties().ToList())
            {
                if (propriedade.CanRead)
                {
                    object value = propriedade.GetValue(objeto, null);
                    DataColumn coluna = tbl.Columns.Add(propriedade.Name, propriedade.PropertyType);
                    dataRow[coluna] = value;
                }
            }

            tbl.Rows.Add(dataRow);
            tbl.AcceptChanges();
            return tbl;
        }

        public static string ToDataFiscal(DateTime data, string FusoHorario)
        {
            return string.Concat(data.Year, "-", data.Month.ToString().PadLeft(2, '0'), "-", data.Day.ToString().PadLeft(2, '0'), "T", data.Hour.ToString().PadLeft(2, '0'), ":", data.Minute.ToString().PadLeft(2, '0'), ":", data.Second.ToString().PadLeft(2, '0'), FusoHorario);
        }

        public partial class Json<T>
        {
            public const string TypeContent = "application/json";
            
            public T Deserializar(string conteudo)
            {
                if (conteudo == string.Empty) return default(T);

                T ret = JsonSerializer.Deserialize<T>(conteudo);

                return ret;
            }

            public string Serializar(T obj)
            {
                if (obj == null) return string.Empty;

                string ret = JsonSerializer.Serialize<T>(obj);

                return ret;
            }

        }
    }
}
