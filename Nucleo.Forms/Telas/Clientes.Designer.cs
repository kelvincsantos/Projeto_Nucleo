
namespace Nucleo.Forms.Telas
{
    partial class Clientes
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
            this.tpRelatorios = new System.Windows.Forms.TabPage();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.viewClientes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tcClientes.SuspendLayout();
            this.tpPesquisar.SuspendLayout();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tcClientes
            // 
            this.tcClientes.Controls.Add(this.tpPesquisar);
            this.tcClientes.Controls.Add(this.tpRelatorios);
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
            this.tpPesquisar.Controls.Add(this.viewClientes);
            this.tpPesquisar.Controls.Add(this.gbFiltro);
            this.tpPesquisar.Location = new System.Drawing.Point(4, 24);
            this.tpPesquisar.Name = "tpPesquisar";
            this.tpPesquisar.Padding = new System.Windows.Forms.Padding(3);
            this.tpPesquisar.Size = new System.Drawing.Size(792, 422);
            this.tpPesquisar.TabIndex = 0;
            this.tpPesquisar.Text = "Pesquisa";
            // 
            // tpRelatorios
            // 
            this.tpRelatorios.Location = new System.Drawing.Point(4, 24);
            this.tpRelatorios.Name = "tpRelatorios";
            this.tpRelatorios.Padding = new System.Windows.Forms.Padding(3);
            this.tpRelatorios.Size = new System.Drawing.Size(792, 422);
            this.tpRelatorios.TabIndex = 1;
            this.tpRelatorios.Text = "Relatórios";
            this.tpRelatorios.UseVisualStyleBackColor = true;
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.button2);
            this.gbFiltro.Controls.Add(this.button1);
            this.gbFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltro.Location = new System.Drawing.Point(3, 3);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(786, 100);
            this.gbFiltro.TabIndex = 0;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Filtro";
            // 
            // viewClientes
            // 
            this.viewClientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.viewClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewClientes.GridColor = System.Drawing.SystemColors.Control;
            this.viewClientes.Location = new System.Drawing.Point(3, 103);
            this.viewClientes.Name = "viewClientes";
            this.viewClientes.RowTemplate.Height = 25;
            this.viewClientes.Size = new System.Drawing.Size(786, 316);
            this.viewClientes.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(691, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "Limpar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcClientes);
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.tcClientes.ResumeLayout(false);
            this.tpPesquisar.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcClientes;
        private System.Windows.Forms.TabPage tpPesquisar;
        private System.Windows.Forms.TabPage tpRelatorios;
        private System.Windows.Forms.DataGridView viewClientes;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}