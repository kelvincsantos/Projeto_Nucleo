using DocumentFormat.OpenXml.Office.CoverPageProps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nucleo.Forms.Telas.Controls
{
    public class Grid
    {

        public enum Tipo
        {
            TextBox,
            CheckBox,
            Image
        }

        public partial class Column
        {
            public Tipo Tipo { get; set; } = Tipo.TextBox;
            public string Titulo { get; set; }
            public string Referencia { get; set; }
            public int Tamanho { get; set; }
            public string Formato { get; set; }
            public DataGridViewContentAlignment? Alinhamento { get; set; } = DataGridViewContentAlignment.MiddleCenter;
        }

        public static void Init(DataGridView view, List<Column> columns, bool style = true, bool PermitirAlteracaoDeRegistro = false)
        {
            view.DataSource = null;

            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            view.AutoGenerateColumns = false;
            view.RowHeadersVisible = false;

            if (style)
            {
                view.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                view.ForeColor = Color.Blue;
                view.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                view.DefaultCellStyle.SelectionForeColor = Color.Blue;
            }

            view.BorderStyle = BorderStyle.None;
            view.BackgroundColor = Color.White;
            if (PermitirAlteracaoDeRegistro)
                view.EditMode = DataGridViewEditMode.EditOnEnter;
            else
                view.EditMode = DataGridViewEditMode.EditProgrammatically;

            view.Columns.Clear();

            foreach (var Column in columns)
            {
                if (Column.Tipo == Tipo.TextBox)
                {
                    DataGridViewTextBoxColumn e = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = Column.Referencia,
                        HeaderText = Column.Titulo,
                        Width = Column.Tamanho
                    };

                    if (Column.Alinhamento != null)
                        e.DefaultCellStyle.Alignment = Column.Alinhamento.Value;

                    view.Columns.Add(e);
                }
                else if (Column.Tipo == Tipo.CheckBox)
                {
                    DataGridViewCheckBoxColumn e = new DataGridViewCheckBoxColumn();

                    e.DataPropertyName = Column.Referencia;
                    e.HeaderText = Column.Titulo;
                    e.Width = Column.Tamanho;
                    e.TrueValue = true;
                    e.FalseValue = false;
                    e.ReadOnly = false;
                    e.ValueType = typeof(bool);

                    if (Column.Alinhamento != null)
                        e.DefaultCellStyle.Alignment = Column.Alinhamento.Value;

                    view.Columns.Add(e);
                }
                else if (Column.Tipo == Tipo.Image)
                {
                    DataGridViewImageColumn e = new DataGridViewImageColumn();

                    e.DataPropertyName = Column.Referencia;
                    e.HeaderText = Column.Titulo;
                    e.Width = Column.Tamanho;
                    e.ReadOnly = false;
                    e.ValueType = typeof(bool);

                    if (Column.Alinhamento != null)
                        e.DefaultCellStyle.Alignment = Column.Alinhamento.Value;

                    view.Columns.Add(e);
                }
            }
        }

        public static void Init2(DataGridView view, List<Column> columns, int TamanhoFonte = 9)
        {

            view.DataSource = null;

            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.MultiSelect = false;
            view.AutoGenerateColumns = false;
            view.RowHeadersVisible = false;

            view.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            view.ForeColor = Color.White;
            view.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            view.DefaultCellStyle.SelectionForeColor = Color.Blue;
            view.BorderStyle = BorderStyle.None;
            view.BackgroundColor = Color.White;
            view.EditMode = DataGridViewEditMode.EditProgrammatically;

            view.Columns.Clear();

            foreach (var Column in columns)
            {
                if (Column.Tipo ==   Tipo.TextBox)
                {
                    DataGridViewTextBoxColumn e = new DataGridViewTextBoxColumn();

                    e.DataPropertyName = Column.Referencia;
                    e.HeaderText = Column.Titulo;
                    e.Width = Column.Tamanho;
                    e.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", TamanhoFonte, FontStyle.Bold);
                    e.DefaultCellStyle.ForeColor = Color.Black;

                    if (Column.Alinhamento != null)
                        e.DefaultCellStyle.Alignment = Column.Alinhamento.Value;

                    view.Columns.Add(e);
                }
                else if (Column.Tipo == Tipo.CheckBox)
                {
                    DataGridViewCheckBoxColumn e = new DataGridViewCheckBoxColumn();

                    e.DataPropertyName = Column.Referencia;
                    e.HeaderText = Column.Titulo;
                    e.Width = Column.Tamanho;
                    e.TrueValue = true;
                    e.FalseValue = false;
                    e.ReadOnly = false;
                    e.ValueType = typeof(bool);

                    if (Column.Alinhamento != null)
                        e.DefaultCellStyle.Alignment = Column.Alinhamento.Value;

                    view.Columns.Add(e);
                }
                else if (Column.Tipo == Tipo.Image)
                {
                    DataGridViewImageColumn e = new DataGridViewImageColumn();

                    e.DataPropertyName = Column.Referencia;
                    e.HeaderText = Column.Titulo;
                    e.Width = Column.Tamanho;
                    e.ReadOnly = false;
                    e.ValueType = typeof(bool);

                    if (Column.Alinhamento != null)
                        e.DefaultCellStyle.Alignment = Column.Alinhamento.Value;

                    view.Columns.Add(e);
                }
            }
        }
    }
}
