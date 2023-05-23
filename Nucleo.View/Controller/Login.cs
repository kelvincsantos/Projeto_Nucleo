using System;
using System.Collections.Generic;
using System.Text;
using Nucleo;
namespace Nucleo.View.Controller
{
    public class Login
    {
        public View.Login Form { get; set; }

        public Login(View.Login e)
        {
            this.Form = e;

            Form.Loaded += Form_Loaded;
            Form.MouseLeftButtonDown += Form_MouseLeftButtonDown;

            Form.txtLogin.PreviewKeyDown += Comum.Textbox.PreviewKeyDown;
            Form.txtSenha.PreviewKeyDown += Comum.Textbox.PreviewKeyDown;
        }


        private void Form_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Form.txtLogin.Focus();
        }

        private void Form_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Form.DragMove();
        }
    }
}
