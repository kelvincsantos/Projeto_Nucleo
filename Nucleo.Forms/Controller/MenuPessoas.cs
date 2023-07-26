using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Nucleo.View.Views;

namespace Nucleo.Forms.Controller
{
    public class MenuPessoas
    {
        private Forms.MenuPessoas form;
        private View.Views.Tela.MenuPessoas view;
        public MenuPessoas(Forms.MenuPessoas e)
        {
            this.form = e;
            this.view = new View.Views.Tela.MenuPessoas();

            Forms.Comum.Leiaute.Tela.Carregar(form);

        }
    }
}
