using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Nucleo.View.Views.Tela
{
    public class MenuPrincipal
    {
        public List<Button> BotoesCadastro { get; set; }
        public List<Button> BotoesOperacoes { get; set; }
        public List<Button> BotoesRelatorios { get; set; }
        public List<Button> BotoesConfiguracoes { get; set; }

        public MenuPrincipal()
        {

        }


        public string Empresa()
        {
            return string.Concat("Empresa: ", Operacoes.BO.MenuPrincipal.DadosEmpresa());
        }

        public string Usuario()
        {
            return string.Concat("Usuário logado: ", Operacoes.BO.MenuPrincipal.DadosEmpresa());
        }

        public string Versao()
        {
            return string.Concat("Versão do Sistema: ", Operacoes.BO.MenuPrincipal.DadosVersao());
        }

        public List<string> CadastrosDisponiveis()
        {
            return Operacoes.BO.MenuPrincipal.CadastrosDisponiveis();
        }

        public void AbrirCadastro(string Modulo)
        {

        }
    }
}
