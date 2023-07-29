using System;
using System.Collections.Generic;
using System.Text;
using Nucleo.Operacoes;

namespace Nucleo.View.Views.Tela
{
    public class Login
    {
        
        public Data.Usuario Acessar(string login, string senha)
        {
             return Operacoes.BO.Logon.EfetuarAcesso(login, senha);
        }
    }
}
