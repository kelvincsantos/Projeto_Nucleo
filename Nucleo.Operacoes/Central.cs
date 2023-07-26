using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes
{
    public class Central
    {

        public static _Dados Dados { get; set; }

        public static _Perifericos Perifericos { get; set; }

        public partial class _Dados
        {
            public Nucleo.Data.Usuario UsuarioLogado { get; set; }
            public Nucleo.Data.Empresa Empresa { get; set; }
            public Nucleo.Data.Configuracao Configuracao { get; set; }

            public _Dados()
            {
                UsuarioLogado = new Data.Usuario();
                Empresa = new Data.Empresa();
                Configuracao = new Data.Configuracao();
            }
        }

        public partial class _Perifericos
        {

        }

        public Central()
        {
            Dados = new _Dados();
        }

        public bool Iniciar()
        {
            EstruturarBancoDeDados();

            if (!Licensa())
                return false;

            Empresa();

            return true;
        }

        private bool Licensa()
        {
            return true;
        }

        public bool Login(string usuario, string senha)
        {
           Dados.UsuarioLogado = BO.Logon.EfetuarAcesso(usuario, senha);

            return Dados.UsuarioLogado != null;
        }

        public void EstruturarBancoDeDados()
        {

        }
        
        public void Empresa()
        {

        }
    }
}
