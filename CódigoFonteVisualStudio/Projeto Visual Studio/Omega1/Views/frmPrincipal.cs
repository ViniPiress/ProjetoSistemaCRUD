using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega1.Views
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastroPF c = new frmCadastroPF();
            c.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pesoaFísicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pessoaJurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pessoaFísicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vizualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastro c = new frmCadastro();
            c.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCadastroCol c = new frmCadastroCol();
            c.ShowDialog();
            this.Close();
            this.Dispose();
        }
    }
}
