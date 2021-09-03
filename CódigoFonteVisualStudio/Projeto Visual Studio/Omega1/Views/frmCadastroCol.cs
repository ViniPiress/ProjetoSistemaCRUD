using MySql.Data.MySqlClient;
using Omega1.DLLs;
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
    public partial class frmCadastroCol : Form
    {
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public frmCadastroCol()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal f = new frmPrincipal();
            f.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpaCampos ui = new LimpaCampos();
            ui.limpa(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
            mConn.Open();
            if (txtBoxID.Text == string.Empty || txtBoxID.Text == string.Empty || txtBoxDepart.Text == string.Empty)
            {
                MessageBox.Show("Há um ou mais campos que não foram preenchidos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO `omega`.`usufunc` (id, nome, senha, departamento)" + "VALUES('" + txtBoxID.Text + "','" + txtBoxNome.Text + "', '" + txtBoxSenha.Text + "', '" + txtBoxDepart.Text + "')", mConn);
                    command.ExecuteNonQuery();
                    mConn.Close();

                    MessageBox.Show("Gravado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    frmPrincipal f = new frmPrincipal();
                    f.ShowDialog();
                    this.Close();
                    this.Dispose();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Este ID ja esta cadastrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM usufunc WHERE id = '" + txtBoxID.Text.Trim() + "';", mConn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtBoxID.Text = reader.GetString("id");
                    txtBoxNome.Text = reader.GetString("nome");
                    txtBoxDepart.Text = reader.GetString("departamento");
                    txtBoxSenha.Text = reader.GetString("senha");

                    mConn.Close();

                }
            }

            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();

                MySqlCommand command = new MySqlCommand("update usufunc set id = '" + txtBoxID.Text.Trim() + "', nome = '" + txtBoxNome.Text.Trim() + "', departamento = '" + txtBoxDepart.Text.Trim() + "' where id = '" + txtBoxID.Text.Trim() + "' ;", mConn);
                command.ExecuteNonQuery();

                MessageBox.Show("Dados atualizados com sucesso!!");
                mConn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show(err.Message);
            }
        }

    }
}

