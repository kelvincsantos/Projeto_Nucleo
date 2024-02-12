
namespace Nucleo.Forms.Telas
{
    partial class GerarEtiqueta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcClientes = new System.Windows.Forms.TabControl();
            this.tpPesquisar = new System.Windows.Forms.TabPage();
            this.lblPreVisualizacao = new System.Windows.Forms.Label();
            this.pbPreVisualizacao = new System.Windows.Forms.PictureBox();
            this.txtDiretorioLaudo = new System.Windows.Forms.TextBox();
            this.lblDiretorioLaudo = new System.Windows.Forms.Label();
            this.txtProximaCalibracao = new System.Windows.Forms.TextBox();
            this.lblProximaCalibracao = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblNroIdentificacao = new System.Windows.Forms.Label();
            this.txtNroCertificacao = new System.Windows.Forms.TextBox();
            this.lblNumeroCertificacao = new System.Windows.Forms.Label();
            this.txtDataCalibracao = new System.Windows.Forms.TextBox();
            this.lblDataCalibracao = new System.Windows.Forms.Label();
            this.btnImprimirEtiqueta = new System.Windows.Forms.Button();
            this.btnGerarQRCode = new System.Windows.Forms.Button();
            this.tcClientes.SuspendLayout();
            this.tpPesquisar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreVisualizacao)).BeginInit();
            this.SuspendLayout();
            // 
            // tcClientes
            // 
            this.tcClientes.Controls.Add(this.tpPesquisar);
            this.tcClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcClientes.Location = new System.Drawing.Point(0, 0);
            this.tcClientes.Name = "tcClientes";
            this.tcClientes.SelectedIndex = 0;
            this.tcClientes.Size = new System.Drawing.Size(800, 450);
            this.tcClientes.TabIndex = 0;
            // 
            // tpPesquisar
            // 
            this.tpPesquisar.BackColor = System.Drawing.SystemColors.Control;
            this.tpPesquisar.Controls.Add(this.lblPreVisualizacao);
            this.tpPesquisar.Controls.Add(this.pbPreVisualizacao);
            this.tpPesquisar.Controls.Add(this.txtDiretorioLaudo);
            this.tpPesquisar.Controls.Add(this.lblDiretorioLaudo);
            this.tpPesquisar.Controls.Add(this.txtProximaCalibracao);
            this.tpPesquisar.Controls.Add(this.lblProximaCalibracao);
            this.tpPesquisar.Controls.Add(this.textBox2);
            this.tpPesquisar.Controls.Add(this.lblNroIdentificacao);
            this.tpPesquisar.Controls.Add(this.txtNroCertificacao);
            this.tpPesquisar.Controls.Add(this.lblNumeroCertificacao);
            this.tpPesquisar.Controls.Add(this.txtDataCalibracao);
            this.tpPesquisar.Controls.Add(this.lblDataCalibracao);
            this.tpPesquisar.Controls.Add(this.btnImprimirEtiqueta);
            this.tpPesquisar.Controls.Add(this.btnGerarQRCode);
            this.tpPesquisar.Location = new System.Drawing.Point(4, 24);
            this.tpPesquisar.Name = "tpPesquisar";
            this.tpPesquisar.Padding = new System.Windows.Forms.Padding(3);
            this.tpPesquisar.Size = new System.Drawing.Size(792, 422);
            this.tpPesquisar.TabIndex = 0;
            this.tpPesquisar.Text = "Pesquisa";
            // 
            // lblPreVisualizacao
            // 
            this.lblPreVisualizacao.AutoSize = true;
            this.lblPreVisualizacao.Location = new System.Drawing.Point(289, 126);
            this.lblPreVisualizacao.Name = "lblPreVisualizacao";
            this.lblPreVisualizacao.Size = new System.Drawing.Size(91, 15);
            this.lblPreVisualizacao.TabIndex = 13;
            this.lblPreVisualizacao.Text = "Pré Visualização";
            // 
            // pbPreVisualizacao
            // 
            this.pbPreVisualizacao.Location = new System.Drawing.Point(289, 144);
            this.pbPreVisualizacao.Name = "pbPreVisualizacao";
            this.pbPreVisualizacao.Size = new System.Drawing.Size(278, 169);
            this.pbPreVisualizacao.TabIndex = 12;
            this.pbPreVisualizacao.TabStop = false;
            // 
            // txtDiretorioLaudo
            // 
            this.txtDiretorioLaudo.Location = new System.Drawing.Point(289, 92);
            this.txtDiretorioLaudo.Name = "txtDiretorioLaudo";
            this.txtDiretorioLaudo.Size = new System.Drawing.Size(372, 23);
            this.txtDiretorioLaudo.TabIndex = 11;
            // 
            // lblDiretorioLaudo
            // 
            this.lblDiretorioLaudo.AutoSize = true;
            this.lblDiretorioLaudo.Location = new System.Drawing.Point(289, 74);
            this.lblDiretorioLaudo.Name = "lblDiretorioLaudo";
            this.lblDiretorioLaudo.Size = new System.Drawing.Size(89, 15);
            this.lblDiretorioLaudo.TabIndex = 10;
            this.lblDiretorioLaudo.Text = "Diretório Laudo";
            // 
            // txtProximaCalibracao
            // 
            this.txtProximaCalibracao.Location = new System.Drawing.Point(80, 290);
            this.txtProximaCalibracao.Name = "txtProximaCalibracao";
            this.txtProximaCalibracao.Size = new System.Drawing.Size(153, 23);
            this.txtProximaCalibracao.TabIndex = 9;
            // 
            // lblProximaCalibracao
            // 
            this.lblProximaCalibracao.AutoSize = true;
            this.lblProximaCalibracao.Location = new System.Drawing.Point(80, 272);
            this.lblProximaCalibracao.Name = "lblProximaCalibracao";
            this.lblProximaCalibracao.Size = new System.Drawing.Size(92, 15);
            this.lblProximaCalibracao.TabIndex = 8;
            this.lblProximaCalibracao.Text = "Prox. Calibração";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 222);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 23);
            this.textBox2.TabIndex = 7;
            // 
            // lblNroIdentificacao
            // 
            this.lblNroIdentificacao.AutoSize = true;
            this.lblNroIdentificacao.Location = new System.Drawing.Point(80, 204);
            this.lblNroIdentificacao.Name = "lblNroIdentificacao";
            this.lblNroIdentificacao.Size = new System.Drawing.Size(98, 15);
            this.lblNroIdentificacao.TabIndex = 6;
            this.lblNroIdentificacao.Text = "Nro Identificação";
            // 
            // txtNroCertificacao
            // 
            this.txtNroCertificacao.Location = new System.Drawing.Point(80, 157);
            this.txtNroCertificacao.Name = "txtNroCertificacao";
            this.txtNroCertificacao.Size = new System.Drawing.Size(153, 23);
            this.txtNroCertificacao.TabIndex = 5;
            // 
            // lblNumeroCertificacao
            // 
            this.lblNumeroCertificacao.AutoSize = true;
            this.lblNumeroCertificacao.Location = new System.Drawing.Point(80, 139);
            this.lblNumeroCertificacao.Name = "lblNumeroCertificacao";
            this.lblNumeroCertificacao.Size = new System.Drawing.Size(93, 15);
            this.lblNumeroCertificacao.TabIndex = 4;
            this.lblNumeroCertificacao.Text = "Nro Certificação";
            // 
            // txtDataCalibracao
            // 
            this.txtDataCalibracao.Location = new System.Drawing.Point(80, 93);
            this.txtDataCalibracao.Name = "txtDataCalibracao";
            this.txtDataCalibracao.Size = new System.Drawing.Size(153, 23);
            this.txtDataCalibracao.TabIndex = 3;
            // 
            // lblDataCalibracao
            // 
            this.lblDataCalibracao.AutoSize = true;
            this.lblDataCalibracao.Location = new System.Drawing.Point(80, 75);
            this.lblDataCalibracao.Name = "lblDataCalibracao";
            this.lblDataCalibracao.Size = new System.Drawing.Size(90, 15);
            this.lblDataCalibracao.TabIndex = 2;
            this.lblDataCalibracao.Text = "Data Calibração";
            // 
            // btnImprimirEtiqueta
            // 
            this.btnImprimirEtiqueta.Location = new System.Drawing.Point(573, 289);
            this.btnImprimirEtiqueta.Name = "btnImprimirEtiqueta";
            this.btnImprimirEtiqueta.Size = new System.Drawing.Size(84, 24);
            this.btnImprimirEtiqueta.TabIndex = 1;
            this.btnImprimirEtiqueta.Text = "Imprimir";
            this.btnImprimirEtiqueta.UseVisualStyleBackColor = true;
            this.btnImprimirEtiqueta.Click += new System.EventHandler(this.btnImprimirEtiqueta_Click);
            // 
            // btnGerarQRCode
            // 
            this.btnGerarQRCode.Location = new System.Drawing.Point(667, 91);
            this.btnGerarQRCode.Name = "btnGerarQRCode";
            this.btnGerarQRCode.Size = new System.Drawing.Size(84, 24);
            this.btnGerarQRCode.TabIndex = 0;
            this.btnGerarQRCode.Text = "Gerar";
            this.btnGerarQRCode.UseVisualStyleBackColor = true;
            this.btnGerarQRCode.Click += new System.EventHandler(this.btnGerarQRCode_Click);
            // 
            // GerarEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcClientes);
            this.Name = "GerarEtiqueta";
            this.Text = "Gerar Etiquetas";
            this.tcClientes.ResumeLayout(false);
            this.tpPesquisar.ResumeLayout(false);
            this.tpPesquisar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreVisualizacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcClientes;
        private System.Windows.Forms.Button btnImprimirEtiqueta;
        private System.Windows.Forms.Button btnGerarQRCode;
        internal System.Windows.Forms.TextBox txtDataCalibracao;
        private System.Windows.Forms.Label lblDataCalibracao;
        internal System.Windows.Forms.TabPage tpPesquisar;
        internal System.Windows.Forms.TextBox txtProximaCalibracao;
        private System.Windows.Forms.Label lblProximaCalibracao;
        internal System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblNroIdentificacao;
        internal System.Windows.Forms.TextBox txtNroCertificacao;
        private System.Windows.Forms.Label lblNumeroCertificacao;
        internal System.Windows.Forms.TextBox txtDiretorioLaudo;
        private System.Windows.Forms.Label lblDiretorioLaudo;
        private System.Windows.Forms.Label lblPreVisualizacao;
        private System.Windows.Forms.PictureBox pbPreVisualizacao;
    }
}