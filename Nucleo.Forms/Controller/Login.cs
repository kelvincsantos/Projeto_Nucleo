using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Nucleo.View.Views;

namespace Nucleo.Forms.Controller
{
    public class Login
    {
        private Forms.Telas.Login form;
        private View.Views.Tela.Login login;

        public Data.Usuario usuario;

        public Login(Forms.Telas.Login e)
        {
            this.form = e;
            this.login = new View.Views.Tela.Login();

            Forms.Comum.Leiaute.Tela.Carregar(form);

            this.form.txtLogin.KeyPress += Comum.Leiaute.TextBox.KeyPress;
            this.form.txtSenha.KeyPress += Comum.Leiaute.TextBox.KeyPress;

            this.form.btnLogin.Click += BtnLogin_Click;
            this.form.btnSair.Click += btnSair_Click;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            usuario = null;
            Sair();
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            usuario = login.Acessar(form.txtLogin.Text.Trim(), form.txtSenha.Text.Trim());
            Sair();
        }

        private void Sair()
        {
            form.Close();
        }
    }
}
