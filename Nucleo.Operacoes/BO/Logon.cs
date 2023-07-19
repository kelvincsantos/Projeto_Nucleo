using System;
using System.Collections.Generic;
using System.Text;
using Nucleo.Data;

namespace Nucleo.Operacoes.BO
{
    public class Logon
    {
        public static bool EfetuarAcesso(string usuario, string senha)
        {
            if (!ChecarLicensa())
                return false;

            Data.Usuario user = ChecarUsuario(usuario);

            if (user == null)
                return false;

            if(user.Senha != senha)
                return false;

            return true;
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
