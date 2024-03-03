using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Forms.Controller
{
    public class GerarEtiqueta
    {
        private Forms.Telas.GerarEtiqueta form;
        private View.Views.Tela.GerarEtiqueta view;

        private List<Etiqueta> etiquetas;

        public GerarEtiqueta(Forms.Telas.GerarEtiqueta e)
        {
            this.form = e;
            this.view = new View.Views.Tela.GerarEtiqueta();


            form.btnGerarQRCode.Click += BtnGerarQRCode_Click;
            form.btnImprimirEtiqueta.Click += BtnImprimirEtiqueta_Click;
        }

        private void BtnGerarQRCode_Click(object sender, EventArgs e)
        {
            form.pbPreVisualizacao.Image = Nucleo.Operacoes.Aplicacao.CodigoBarras.GenerateQRCode(form.txtDiretorioLaudo.Text);
        }

        private void BtnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            form.txtDataCalibracao.Text = string.Empty;
            form.txtDiretorioLaudo.Text = string.Empty;
            form.txtNroCertificacao.Text = string.Empty;
        }


        private void Carregar()
        {
            string arquivo = string.Empty;

            etiquetas = view.CarregarLista(arquivo);

            Mostrar();
        }

        private void Mostrar()
        {
            //CARREGAR UM GRID NA TELA COM AS ETIQUETAS JÁ ADICIONADAS NA LISTA
        }
    }
}
