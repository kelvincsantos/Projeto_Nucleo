using System;
using System.Collections.Generic;
using System.Text;
using Nucleo.Data;

namespace Nucleo.Operacoes.BO
{
    public class Logon
    {
        public static Data.Usuario EfetuarAcesso(string usuario, string senha)
        {
            if (!ChecarLicensa())
                return null;

            Data.Usuario user = ChecarUsuario(usuario);

            if (user == null)
                return null;

            if(user.Senha != senha)
                return null;

            return user;
        }


        private static bool ChecarLicensa()
        {
            return true;
        }

        private static Data.Usuario ChecarUsuario(string usuario)
        {
            return ADO.Usuario.BuscarPorUsuario(usuario);
        }
    }
}
