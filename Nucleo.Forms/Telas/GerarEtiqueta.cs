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
        public Controller.GerarEtiqueta controller;

        public GerarEtiqueta()
        {
            InitializeComponent();

            controller = new Controller.GerarEtiqueta(this);
        }
    }
}
