using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nucleo.Forms.Controller
{
    public class MenuPrincipal
    {
        private Telas.MenuPrincipal form;
        //private View.Views.Tela.MenuPrincipal view;
        public MenuPrincipal(Telas.MenuPrincipal e)
        {
            this.form = e;
            //this.view = new View.Views.Tela.MenuPrincipal();


            form.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            CarregarBotoes();
            CarregarTopo();
        }
        
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            form.Close();
            Application.Exit();
        }

        private void CarregarTopo()
        {
            //form.lblEmpresa.Text = view.Empresa();
            //form.lblUsuario.Text = view.Usuario();
            //form.lblVersao.Text = view.Versao();
        }

        private void CarregarBotoes()
        {
            CarregarCadastros();
        }

        private void CarregarCadastros()
        {
            List<Control> controls = new List<Control> {
                form.btnCadastro1, form.btnCadastro2, form.btnCadastros3, form.btnCadastro4, form.btnCadastro5, form.btnCadastro6, form.btnCadastro7
            };

            List<string> cadastros = new List<string>();
            //List<string> cadastros = view.CadastrosDisponiveis();

            for (int i = 0; i < cadastros.Count; i++)
            {
                controls[i].Click += Generic_Click;
                controls[i].Text = cadastros[i];
                controls[i].Visible = true;
            }
        }
        private void Generic_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            if (control.GetType() != typeof(Button))
                control = control.Parent;

            string key = control.Text;

            AbrirCadastro(key);
        }

        private void AbrirCadastro(string Modulo)
        {
            //if (Modulo.ToLower().Equals(View.Views.Tela.MenuPrincipal.Modulos.pessoas.ToString()))
            //    Comum.Leiaute.Tela.ExibirMedio(new Nucleo.Forms.MenuPessoas());

        }
    }
}
