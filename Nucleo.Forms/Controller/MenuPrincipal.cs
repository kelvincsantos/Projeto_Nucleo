using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Nucleo.View.Views;

namespace Nucleo.Forms.Controller
{
    public class MenuPrincipal
    {
        private Forms.MenuPrincipal form;
        private View.Views.Tela.MenuPrincipal menuPrincipal;
        public MenuPrincipal(Forms.MenuPrincipal e)
        {
            this.form = e;
            this.menuPrincipal = new View.Views.Tela.MenuPrincipal();

            Forms.Comum.Leiaute.Tela.Carregar(form);
            Forms.Comum.Leiaute.Tela.Tamanho(form, Comum.Leiaute.Tela.Tamanhos.Grande);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            form.Close();
            Application.Exit();
        }
    }
}
