using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nucleo.Forms
{
    public partial class MenuPessoas : Form
    {
        public Controller.MenuPessoas controller;

        public MenuPessoas()
        {
            InitializeComponent();

            controller = new Controller.MenuPessoas(this);
        }
    }
}
