using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nucleo.Forms.Telas
{
    public partial class GerarEtiqueta : Form
    {
        public GerarEtiqueta()
        {
            InitializeComponent();
        }

        private void btnGerarQRCode_Click(object sender, EventArgs e)
        {
            pbPreVisualizacao.Image = Nucleo.Operacoes.Aplicacao.CodigoBarras.GenerateQRCode(txtDiretorioLaudo.Text);
        }

        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            txtDataCalibracao.Text = string.Empty;
            txtDiretorioLaudo.Text = string.Empty;
            txtNroCertificacao.Text = string.Empty;
        }

        
    }
}
