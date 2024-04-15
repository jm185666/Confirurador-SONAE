using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Acerca : Form
    {
        public Acerca()
        {
            InitializeComponent();
            this.TopMost = true;
            textBoxCUSTOMER.Text = WindowsFormsApp1.Form1.customer;
            textBoxRELEASE.Text = WindowsFormsApp1.Form1.image_release;
            labelVERSION.Text = WindowsFormsApp1.Form1.version;
        }
     }
}
