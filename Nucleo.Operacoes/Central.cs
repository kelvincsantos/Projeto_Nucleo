using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes
{
    public class Central
    {
        public static Central Principal { get; set; }

        public _Dados Dados { get; set; }

        public _Perifericos Perifericos { get; set; }

        public partial class _Dados
        {
            public Nucleo.Data.Usuario UsuarioLogado { get; set; }
            public Nucleo.Data.Empresa Empresa { get; set; }
            public Nucleo.Data.Configuracao Configuracao { get; set; }

            public string Versao { get; set; }

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
            Perifericos = new _Perifericos();
        }

        public bool Iniciar(Central e)
        {
            Principal = e;

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

        public bool Login(Data.Usuario e)
        {
            Dados.UsuarioLogado = e;

            return Dados.UsuarioLogado != null;
        }

        public void EstruturarBancoDeDados()
        {

        }
        
        public void Empresa()
        {
            Principal.Dados.Empresa = new Data.Empresa()
            {
                CNPJ = "12.123.123/0001-12",
                NomeFantasia = "Empresa Teste LTDA",
                RazaoSocial = "Empresa Teste Eirelli",
            };
        }
        public void Versao(string versao)
        {
            Principal.Dados.Versao = versao;
        }
    }
}
