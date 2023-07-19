using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Nucleo.View.Comum
{
    public static class Mensagem
    {
        public static void Sucesso(string mensagem)
        {
            MessageBox.Show(mensagem, "!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
