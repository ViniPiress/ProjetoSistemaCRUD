using Omega1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega1
{
    public partial class frmCarrega : Form
    {
        public frmCarrega()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Carregamento para a tela de login
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            else
            {
                timer1.Enabled = false;
                frmLogin log = new frmLogin();
                log.Show();
                this.Visible = false;
            }
        }

        private void frmCarrega_Load(object sender, EventArgs e)
        {

        }

    }
}
