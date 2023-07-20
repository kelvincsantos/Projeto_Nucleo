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
    public partial class MenuPrincipal : Form
    {
        public Controller.MenuPrincipal controller;

        public MenuPrincipal()
        {
            InitializeComponent();

            controller = new Controller.MenuPrincipal(this);
        }
    }
}
