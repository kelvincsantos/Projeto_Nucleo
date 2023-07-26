using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes
{
    public class Central
    {

        public static DadosBasicos Dados { get; set; }

        public partial class DadosBasicos
        {
            public Nucleo.Data.Usuario UsuarioLogado { get; set; }
            public Nucleo.Data.Empresa Empresa { get; set; }
            public Nucleo.Data.Configuracao Configuracao { get; set; }

            public DadosBasicos()
            {
                UsuarioLogado = new Data.Usuario();
                Empresa = new Data.Empresa();
                Configuracao = new Data.Configuracao();
            }
        }

        public Central()
        {
            Dados = new DadosBasicos();
        }

        public bool Iniciar()
        {
            

            EstruturarBancoDeDados();

            if (!Licensa())
                return false;

            return true;
        }

        private bool Licensa()
        {
            return true;
        }

        public bool Login(string usuario, string senha)
        {
           Sessao.UsuarioLogado = BO.Logon.EfetuarAcesso(usuario, senha);

            return Sessao.UsuarioLogado != null;
        }

        public void EstruturarBancoDeDados()
        {

        }
        
    }
}
