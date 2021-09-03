using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Omega1.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtBoxSenha.PasswordChar = '*';
            txtBoxChave.PasswordChar = '*';
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            logar();
        }
        private void logar()
        {
            bool flag = false;
            if ((txtBoxUsuario.Text != string.Empty) && (txtBoxSenha.Text != string.Empty) && (txtBoxChave.Text != string.Empty))
            {
                string CONFIG = "server=localhost;database=omega;uid=root;password=12345";
                MySqlConnection conexao = new MySqlConnection(CONFIG);
                MySqlCommand query = new MySqlCommand();
                query.Connection = conexao;
                conexao.Open();
                query.CommandText = "SELECT nome,senha FROM `omega`.`usufunc` WHERE `nome` = '" + txtBoxUsuario.Text.Trim() + "' and `senha` = '" + txtBoxSenha.Text.Trim() + "'";
                query.CommandText = "SELECT departamento FROM `omega`.`usufunc` WHERE `departamento` = '" + txtBoxChave.Text.Trim() + "'";
                bool linhas = query.ExecuteReader().HasRows;
                if (linhas)
                { 
                    this.Hide();
                    frmPrincipal f = new frmPrincipal();
                    f.ShowDialog();
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Usuário,senha ou departamento inválidos");
                }
                conexao.Close();
            }
            else
            {
                if (txtBoxUsuario.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Usuário'");
                    flag = true;
                }
                if (txtBoxSenha.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Senha'");
                    flag = true;
                }
                if (txtBoxChave.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Chave'");
                    flag = true;
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            frmLogin l = new frmLogin();
            l.Close();
          
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAjuda a = new frmAjuda();
            a.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void txtBoxUsuario_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBoxChave_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void txtBoxSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
