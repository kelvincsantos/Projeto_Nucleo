using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Nucleo.View.Views;

namespace Nucleo.Forms.Controller
{
    public class Login
    {
        private Forms.Login form;
        private View.Views.Tela.Login login;
        public Login(Forms.Login e)
        {
            this.form = e;
            this.login = new View.Views.Tela.Login();

            Forms.Comum.Leiaute.Tela.Carregar(form);

            this.form.txtLogin.KeyPress += Comum.Leiaute.TextBox.KeyPress;
            this.form.txtSenha.KeyPress += Comum.Leiaute.TextBox.KeyPress;

            this.form.btnLogin.Click += BtnLogin_Click;
            this.form.btnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            form.Close();
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            login.Acessar(form.txtLogin.Text.Trim(), form.txtSenha.Text.Trim());
        }
    }
}
