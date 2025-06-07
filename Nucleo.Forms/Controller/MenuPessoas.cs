using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nucleo.Forms.Controller
{
    public class MenuPessoas
    {
        private Forms.MenuPessoas form;
        //private View.Views.Tela.MenuPessoas view;
        public MenuPessoas(Forms.MenuPessoas e)
        {
            this.form = e;
            //this.view = new View.Views.Tela.MenuPessoas();

            form.btnClientes.Click += BtnClientes_Click;

            Forms.Comum.Leiaute.Tela.Carregar(form);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Comum.Leiaute.Tela.ExibirMedio(new Nucleo.Forms.Telas.Clientes());
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        
       
    }
}
