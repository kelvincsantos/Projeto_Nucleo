using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nucleo.Foms.Comum
{
    public static class Mensagem
    {
        public static void Sucesso(string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void Alerta(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void Validacao(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static DialogResult QuestaoSimNao(string mensagem)
        {
            return MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static DialogResult QuestaoOkCancelar(string mensagem)
        {
            return MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
