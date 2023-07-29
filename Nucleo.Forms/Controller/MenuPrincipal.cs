using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Nucleo.View.Views;

namespace Nucleo.Forms.Controller
{
    public class MenuPrincipal
    {
        private Telas.MenuPrincipal form;
        private View.Views.Tela.MenuPrincipal view;
        public MenuPrincipal(Telas.MenuPrincipal e)
        {
            this.form = e;
            this.view = new View.Views.Tela.MenuPrincipal();

            form.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            CarregarTopo();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            form.Close();
            Application.Exit();
        }

        private void CarregarTopo()
        {
            form.lblEmpresa.Text = view.Empresa();
            form.lblUsuario.Text = view.Usuario();
            form.lblVersao.Text = view.Versao();
        }
    }
}
