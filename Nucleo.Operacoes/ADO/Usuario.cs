using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes.ADO
{
    public class Usuario
    {
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
    }
}
