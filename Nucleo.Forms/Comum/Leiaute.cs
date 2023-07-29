using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Forms.Comum
{
    public static class Leiaute
    {
        public static partial class TextBox
        {
            public static void KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;
            }

            public static void KeyPress_Decimal(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;


            }

            public static void KeyPress_Integer(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (Conversor.EnterToTab(e.KeyChar))
                    e.Handled = true;


            }

            public static void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                throw new NotImplementedException();
            }

            public static void LostFocus(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

        }

        public static partial class ComboBox
        {

        }

        public static partial class Tela
        {
            public static void Carregar(System.Windows.Forms.Form e)
            {
                e.ForeColor = System.Drawing.Color.DarkBlue;
                e.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            }

            public static void Tamanho(System.Windows.Forms.Form e, Tamanhos tamanho)
            {
                if (tamanho == Tamanhos.Pequeno)
                {
                    e.Width = 600;
                    e.Height = 400;
                }
                else if (tamanho == Tamanhos.Medio)
                {
                    e.Width = 820;
                    e.Height = 420;
                }
                else if (tamanho == Tamanhos.Grande)
                {
                    e.Width = 1080;
                    e.Height = 720;
                }
            }

            public static void ExibirPequeno(System.Windows.Forms.Form e)
            {
                Carregar(e);
                Tamanho(e, Tamanhos.Pequeno);
                e.ShowDialog();
            }

            public static void ExibirMedio(System.Windows.Forms.Form e)
            {
                Carregar(e);
                Tamanho(e, Tamanhos.Medio);
                e.ShowDialog();
            }

            public static void ExibirGrande(System.Windows.Forms.Form e)
            {
                Carregar(e);
                Tamanho(e, Tamanhos.Grande);
                e.ShowDialog();
            }

            public enum Tamanhos
            {
                Pequeno = 1,
                Medio = 2,
                Grande = 3,
            }
        }
    }
}
