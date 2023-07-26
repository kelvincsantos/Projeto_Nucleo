using System;
using System.Collections.Generic;
using System.Text;
using Nucleo.Operacoes;

namespace Nucleo.View.Views.Tela
{
    public class Login
    {
        
        public void Acessar(string login, string senha)
        {
            Operacoes.Central.Login(login, senha);
        }
    }
}
