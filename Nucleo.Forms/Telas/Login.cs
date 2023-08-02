using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nucleo.Forms.Telas
{
    public partial class Login : Form
    {
        public Controller.Login controller;

        public Login()
        {
            InitializeComponent();

            controller = new Controller.Login(this);
        }

    }
}
