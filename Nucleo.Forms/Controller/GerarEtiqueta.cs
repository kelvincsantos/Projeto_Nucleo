using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Nucleo.Forms.Comum;
using Nucleo.Foms.Comum;
using System.Linq;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Nucleo.Forms.Controller
{
    public class GerarEtiqueta
    {
        private Forms.Telas.GerarEtiqueta form;
        private View.Views.Tela.GerarEtiqueta view;

        private List<Etiqueta> etiquetas;
        private Etiqueta Editando;

        public GerarEtiqueta(Forms.Telas.GerarEtiqueta e)
        {
            this.form = e;
            this.view = new View.Views.Tela.GerarEtiqueta();


            form.btnGerarQRCode.Click += BtnGerarQRCode_Click;
            form.btnImprimirEtiqueta.Click += BtnImprimirEtiqueta_Click;

            form.btnImportarExcel.Click += btnImportarExcel_Click;
            form.btnArquivoPadrao.Click += btnArquivoPadrao_Click;
            form.btnAdicionar.Click += btnAdicionar_Click;

            form.dgvEtiquetas.DoubleClick += dgvEtiquetas_DoubleClick;

        }

        private void dgvEtiquetas_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {

            view.CarregarLista("");
        }

        private void btnArquivoPadrao_Click(object sender, EventArgs e)
        {
            view.GerarArquivoPadrao();
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

        private void Selecionar()
        {
            foreach (DataGridViewRow Row in form.dgvEtiquetas.SelectedRows)
            {
                Etiqueta Item = (Etiqueta)Row.DataBoundItem;

                CarregarDetalhes(Item);
            }
        }

        private void Carregar()
        {
            string arquivo = string.Empty;

            etiquetas = view.CarregarLista(arquivo);

            Mostrar();
        }

        private void CarregarDetalhes(Etiqueta e)
        {
            form.txtDataCalibracao.Text = e.DataCalibracao.GetValueOrDefault().ToShortDateString();
            form.txtProximaCalibracao.Text = e.ProximaCalibracao.GetValueOrDefault().ToShortDateString();

            form.txtDiretorioLaudo.Text = e.DiretorioLaudo;
            form.txtNroCertificacao.Text = e.NumeroCertificado;
            form.textBox2.Text = e.NumeroIdentificacao;

            form.pbPreVisualizacao.Image = Nucleo.Operacoes.Aplicacao.CodigoBarras.GenerateQRCode(form.txtDiretorioLaudo.Text);
            Editando = e;
        }

        private void Mostrar()
        {
            //CARREGAR UM GRID NA TELA COM AS ETIQUETAS JÁ ADICIONADAS NA LISTA
            

            if (etiquetas.Count == 0)
            {
                //Mensagem.Alerta("Registros não encontrados");

                return;
            }

           List<Telas.Controls.Grid.Column> Columns = new List<Telas.Controls.Grid.Column>();

            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Pedido Applay", Referencia = "PedidoApp", Tamanho = 50 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "CPF/CNPJ", Referencia = "Documento", Tamanho = 50 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Nome", Referencia = "NomeCliente", Tamanho = 120, Alinhamento = DataGridViewContentAlignment.MiddleLeft });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Qtd. Produto", Referencia = "QuantidadeProdutos", Tamanho = 50, Alinhamento= DataGridViewContentAlignment.MiddleRight });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Vl. Total", Referencia = "ValorProdutos", Tamanho = 50, Alinhamento = DataGridViewContentAlignment.MiddleRight });

            Telas.Controls.Grid.Init(form.dgvEtiquetas, Columns);

            form.dgvEtiquetas.DataSource = etiquetas;
            form.dgvEtiquetas.Focus();
        }

        private void Adicionar()
        {
            if (string.IsNullOrWhiteSpace(form.txtDataCalibracao.Text))
            {
                Mensagem.Alerta("Campo data de calibração obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtProximaCalibracao.Text))
            {
                Mensagem.Alerta("Campo próxima calibração obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.textBox2.Text))
            {
                Mensagem.Alerta("Campo núm. identificação obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtNroCertificacao.Text))
            {
                Mensagem.Alerta("Campo núm. Certificação obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtDiretorioLaudo.Text))
            {
                Mensagem.Alerta("Campo diretório do Laudo obrigatório para gerar etiqueta.");
                return;
            }

            if (etiquetas == null)
                etiquetas = new List<Etiqueta>();

            if (Editando != null)
                etiquetas.Remove(etiquetas.FirstOrDefault(x => x.ID == Editando.ID));
            else
                Editando = new Etiqueta() { ID = Guid.NewGuid().ToString()};


            Editando.DataCalibracao = Convert.ToDateTime(form.txtDataCalibracao.Text.Trim());
            Editando.DiretorioLaudo = form.txtDiretorioLaudo.Text.Trim();
            Editando.NumeroCertificado = form.txtNroCertificacao.Text.Trim();
            Editando.NumeroIdentificacao = form.textBox2.Text.Trim();
            Editando.ProximaCalibracao = Convert.ToDateTime(form.txtProximaCalibracao.Text.Trim());

            etiquetas.Add(Editando);
        }
    }
}
