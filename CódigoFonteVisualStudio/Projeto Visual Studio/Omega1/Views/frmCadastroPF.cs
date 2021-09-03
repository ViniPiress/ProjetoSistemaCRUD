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
    public partial class frmCadastroPF : Form
    {
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;
        public frmCadastroPF()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpaCampos ui = new LimpaCampos();
            ui.limpa(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cadastrarpf();
        }
        private void cadastrarpf()
        {
            mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
            mConn.Open();
            if (txtBoxNome.Text == string.Empty || doUpSexo2.Text == string.Empty || txtBoxCPF.Text == string.Empty || txtBoxEnde.Text == string.Empty || txtBoxNEnde.Text == string.Empty || txtBoxTel.Text == string.Empty || txtBoxCP.Text == string.Empty || txtBoxPub.Text == string.Empty || checkBox2.Text == string.Empty || txtBoxEmail.Text == string.Empty)
            {
                MessageBox.Show("Há um ou mais campos que não foram preenchidos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else 
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO `omega`.`usuclipf` (cpf, nome, sexo, endereco, nendereco, cependereco, tele, email, criptomoeda, cprivada, cpublica)" + "VALUES('" + txtBoxCPF.Text + "','" + txtBoxNome.Text + "', '" + doUpSexo2.Text + "','" + txtBoxEnde.Text + "', '" + txtBoxNEnde.Text + "', '" + txtBoxCEP.Text + "', '" + txtBoxTel.Text + "', '" + txtBoxEmail.Text + "', '" + checkBox2.Text + "', '" + txtBoxCP.Text + "', '" + txtBoxPub.Text + "'  )", mConn);             
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
                    MessageBox.Show("Este CPF ja esta cadastrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                      
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal f = new frmPrincipal();
            f.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();

                MySqlCommand command = new MySqlCommand("delete from usuclipf where cpf= '" + txtBoxCPF.Text.Trim() + "';", mConn);
                command.ExecuteNonQuery();

                MessageBox.Show("Usuario deletado com sucesso!!");
                mConn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();

                MySqlCommand command = new MySqlCommand("update usuclipf set nome = '" + txtBoxNome.Text.Trim() + "', sexo = '" + doUpSexo2.Text.Trim() + "',  endereco = '" + txtBoxEnde.Text.Trim() + "', nendereco = '" + txtBoxNEnde.Text.Trim() + "', cependereco = '" + txtBoxCEP.Text.Trim() + "', tele = '" + txtBoxTel.Text.Trim() + "', email = '" + txtBoxEmail.Text.Trim() + ", criptomoeda = '" + checkBox2.Text.Trim() + "',  cprivada = '" + txtBoxCP.Text.Trim() + "', cpublica = '" + txtBoxPub.Text.Trim() + "' where cpf = '" + txtBoxCPF.Text.Trim() + "' ;", mConn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            procurarpf();
        }
        private void procurarpf()
        {
            try
            {

                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM usuclipf WHERE cpf = '" + txtBoxCPF.Text.Trim() + "';", mConn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtBoxCPF.Text = reader.GetString("cpf");
                    txtBoxNome.Text = reader.GetString("nome");
                    doUpSexo2.Text = reader.GetString("sexo");
                    txtBoxEnde.Text = reader.GetString("endereco");
                    txtBoxNEnde.Text = reader.GetString("nendereco");
                    txtBoxCEP.Text = reader.GetString("cependereco");
                    txtBoxTel.Text = reader.GetString("tele");
                    txtBoxEmail.Text = reader.GetString("email");
                    checkBox2.Text = reader.GetString("criptomoeda");
                    txtBoxCP.Text = reader.GetString("cprivada");
                    txtBoxPub.Text = reader.GetString("cpublica");
                    mConn.Close();

                }
            }

            catch (Exception ex)
            {
              
            }
        }

    }

}
