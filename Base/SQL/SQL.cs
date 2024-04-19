using DocumentFormat.OpenXml.Office.Word;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nucleo.Base.SQL
{
    public class SQL
    {
        public Exception erro { get; set; }

        private string ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        
        public SQL(string servidor, string banco, string senha) 
        {
            ConnectionString = string.Concat("data source=", servidor, ";");

            if (!string.IsNullOrWhiteSpace(banco))
            {
                ConnectionString += string.Concat("initial catalog=", banco, ";");
            }
            ConnectionString = "user id=sa;password=" + senha + ";connection timeout=20";

            conn = new SqlConnection(ConnectionString);
            
        }

        public bool CriarBanco(string nomeBanco)
        {
            string local = Environment.CurrentDirectory;
            if (ExisteBanco(nomeBanco))
            {
                erro = new Exception("banco " + nomeBanco + " já existente.");
                return false;
            }
            string sql = "CREATE DATABASE " + nomeBanco + " ON PRIMARY"
                + "(Name=" + nomeBanco + ", filename = '" + System.IO.Path.Combine(local, nomeBanco) + "_data.mdf', size=3,"
                + "maxsize=5, filegrowth=10%)log on"
                + "(name=" + nomeBanco+  "_log, filename='C:\\SQL_DB\\" + System.IO.Path.Combine(local, nomeBanco) + "_log.ldf',size=3,"
                + "maxsize=20,filegrowth=1)";

            return Executar(sql);
        }

        public bool ExisteBanco(string nomeBanco)
        {
            string SQL = "SELECT name FROM master.sys.databases WHERE name = N'" + nomeBanco + "'";

            SqlDataReader r = Ler(SQL);

            if (r == null)
                return false;

            return r.HasRows;
        }

        private bool Executar(string sql)
        {
            try
            {
                if (!AbrirConexao())
                    return false;

                cmd = new SqlCommand(sql, conn);
                cmd.BeginExecuteNonQuery();
            }
            catch (Exception ex)
            {
                erro = ex;
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        private SqlDataReader Ler(string sql)
        {
            SqlDataReader reader = null;
            try
            {
                if (!AbrirConexao())
                    return null;

                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                erro = ex; 
                return null;
            }

            return reader;
        }

        private bool AbrirConexao()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                erro = ex;
                return false;
            }
            
        }



        private static T ReaderToObject<T>(this SqlDataReader rd) where T : class, new()
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < rd.FieldCount; i++)
            {
                if (!rd.IsDBNull(i))
                {
                    string fieldName = rd.GetName(i);

                    if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldName] = rd.GetValue(i);
                    }
                }
            }

            return t;
        }
    }
}
