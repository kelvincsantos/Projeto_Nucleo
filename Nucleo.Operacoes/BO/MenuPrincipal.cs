using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes.BO
{
    public class MenuPrincipal
    {
        public static string DadosEmpresa()
        {
            return string.Concat(Central.Principal.Dados.Empresa.CNPJ, " - ", Central.Principal.Dados.Empresa.RazaoSocial);
        }

        public static string DadosUsuario()
        {
            return string.Concat(Central.Principal.Dados.UsuarioLogado.ID, " - ", Central.Principal.Dados.UsuarioLogado.Nome);
        }

        public static string DadosVersao()
        {
            return string.Concat("Gerenciador Executivo - v", Central.Principal.Dados.Versao);
        }

    }
}
