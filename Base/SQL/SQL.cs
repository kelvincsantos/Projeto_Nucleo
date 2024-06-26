using DocumentFormat.OpenXml.Office.Word;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static Nucleo.Base.SQL.SQL;

namespace Nucleo.Base.SQL
{
    public class SQL
    {
        public Exception erro { get; set; }

        private Conexao conexao;
        private SqlConnection conn;
        private SqlCommand cmd;

        public SQL(string servidor, string banco, string senha)
        {
            try
            {
                conexao = new Conexao()
                {
                    Banco = "master",
                    Endereco = servidor,
                    Senha = senha,
                };

                conn = new SqlConnection(conexao.ConnectionString());

                if (!ExisteBanco(banco))
                {
                    CriarBanco(banco);
                    CriarTabelasFundamentais();
                }

                conexao.Banco = banco;

                conn = new SqlConnection(conexao.ConnectionString());
            }
            catch (Exception ex)
            {
                erro = ex;
            }
        }

        public SQL(SQL.Conexao con)
        {
            try
            {
                conexao = con;

                string banco = con.Banco;
                conexao.Banco = "master";

                conn = new SqlConnection(conexao.ConnectionString());

                if (!ExisteBanco(banco))
                {
                    CriarBanco(banco);

                    conexao.Banco = banco;
                    conn = new SqlConnection(conexao.ConnectionString());

                    CriarTabelasFundamentais();
                }
                else
                {
                    conexao.Banco = banco;
                    conn = new SqlConnection(conexao.ConnectionString());
                }
            }
            catch (Exception ex)
            {
                erro = ex;
            }
        }

        private bool CriarBanco(string nomeBanco)
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
                + "(name=" + nomeBanco + "_log, filename='" + System.IO.Path.Combine(local, nomeBanco) + "_log.ldf',size=3,"
                + "maxsize=20,filegrowth=1)";

            return Executar(sql);
        }

        private bool ExisteBanco(string nomeBanco)
        {
            string SQL = "SELECT name FROM master.sys.databases WHERE name = N'" + nomeBanco + "'";

            SqlDataReader r = Ler(SQL);

            if (r == null)
                return false;

            return r.HasRows;
        }

        private void CriarTabelasFundamentais()
        {
            Tabelas tabelas = new Tabelas(this);

            tabelas.CriarEtiquetas();
            tabelas.CriarFilaImpressao();
            tabelas.CriarConfiguracao();
        }

        public bool Executar(string sql)
        {
            try
            {
                if (!AbrirConexao())
                    return false;

                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
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

        public SqlDataReader Ler(string sql)
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

        //private static T ReaderToObject<T>(this SqlDataReader rd) where T : class, new()
        //{
        //    Type type = typeof(T);
        //    var accessor = TypeAccessor.Create(type);
        //    var members = accessor.GetMembers();
        //    var t = new T();

        //    for (int i = 0; i < rd.FieldCount; i++)
        //    {
        //        if (!rd.IsDBNull(i))
        //        {
        //            string fieldName = rd.GetName(i);

        //            if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
        //            {
        //                accessor[t, fieldName] = rd.GetValue(i);
        //            }
        //        }
        //    }

        //    return t;
        //}

        public partial class Conexao
        {
            public Conexao(string config)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(config))
                        return;

                    this.Endereco = config.Split('|')[0];
                    this.Banco = config.Split('|')[1];
                    this.Senha = config.Split('|')[2];
                }
                catch (Exception)
                {
                    this.Endereco = string.Empty;
                    this.Banco = string.Empty;
                    this.Senha = string.Empty;
                }
            }

            public Conexao() { }

            public string Endereco { get; set; }
            public string Banco { get; set; }
            public string Senha { get; set; }

            public string ConnectionString()
            {
                string ConnectionString = string.Concat("data source=", Endereco, ";");

                if (!string.IsNullOrWhiteSpace(Banco))
                {
                    ConnectionString += string.Concat("initial catalog=", Banco, ";");
                }
                ConnectionString += "user id=sa;password=" + Senha + ";connection timeout=20";


                return ConnectionString;
            }
        }
    }
}
