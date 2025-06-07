using DocumentFormat.OpenXml.Office2010.Excel;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Nucleo.Operacoes.ADO
{
    public class Usuario
    {

        public Nucleo.Base.SQL.SQL banco { get; set; }
        public Usuario(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }


        public List<Data.Usuario> BuscarTodos()
        {
            string Query = "";
            Query += "  SELECT          ID              " + Environment.NewLine;
            Query += "         ,		[Login]         " + Environment.NewLine;
            Query += "         ,		Senha           " + Environment.NewLine;
            Query += "         ,		Ativo           " + Environment.NewLine;
            Query += "         ,		Nome            " + Environment.NewLine;
            Query += "         ,		DataCriacao     " + Environment.NewLine;
            Query += "         ,		Email           " + Environment.NewLine;
            Query += "  FROM        Usuario             " + Environment.NewLine;

            SqlDataReader reader = banco.Ler(Query);

            return Read(reader);
        }

        public static Data.Usuario BuscarPorUsuario(string Usuario)
        {
            return new Data.Usuario()
            {
                Ativo = true,
                DataCriacao = DateTime.Now,
                Email = "kelvincsantos@gmail.com",
                ID = "pkey",
                Login = "KELVIN",
                Nome = "Kelvin Carvalho Santos",
                Senha = "123",
            };
        }



        public List<Data.Usuario> Read(SqlDataReader reader)
        {
            List<Data.Usuario> lista = new List<Data.Usuario>();

            if (reader == null)
                return lista;

            if (!reader.HasRows)
                return lista;

            while (reader.Read())
            {
                Data.Usuario item = new Data.Usuario();

                item.ID = reader["ID"].ToString();
                item.Ativo = (bool?)reader["Ativo"];
                item.DataCriacao = (DateTime?)reader["DataCriacao"];
                item.Email = reader["Email"].ToString();
                item.Senha = reader["Senha"].ToString();
                item.Login = reader["Login"].ToString();
                item.Nome = reader["Nome"].ToString();

                lista.Add(item);
            }

            return lista;
        }
    }
}
