using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
            this.TopMost = true;
            this.Text = "Salir o Reiniciar?";
        }

        private void QUIT_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();  //Salir
        }
    }
}
