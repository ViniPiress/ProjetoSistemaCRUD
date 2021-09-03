using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using Omega1.DLLs;

namespace Omega1.Views
{
    public partial class frmCadastro : Form
    {
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public frmCadastro()
        {
            InitializeComponent();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cadastrarpj();

        }

        private void cadastrarpj()
        {
            mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
            mConn.Open();
            if (txtBoxNome.Text == string.Empty || doUpSexo.Text == string.Empty || txtBoxCNPJ.Text == string.Empty || txtBoxRaz.Text == string.Empty || txtBoxNF.Text == string.Empty || txtBoxEnde.Text == string.Empty || txtBoxNEnde.Text == string.Empty || txtBoxTel.Text == string.Empty || txtBoxCP.Text == string.Empty || txtBoxPub.Text == string.Empty || checkBoxCript.Text == string.Empty || txtBoxEmail.Text == string.Empty)
            {
                MessageBox.Show("Há um ou mais campos que não foram preenchidos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO `omega`.`usuclipj` (cnpj, nome, sexo, razsoc, endereco, nendereco, cependereco, tele, nfantasia, email, wsite, criptomoeda, cprivada, cpublica)" + "VALUES('" + txtBoxCNPJ.Text + "','" + txtBoxNome.Text + "', '" + doUpSexo.Text + "', '" + txtBoxRaz.Text + "', '" + txtBoxEnde.Text + "', '" + txtBoxNEnde.Text + "', '" + txtBoxCEP.Text + "', '" + txtBoxTel.Text + "', '" + txtBoxNF.Text + "', '" + txtBoxEmail.Text + "', '" + txtBoxWsite.Text + "', '" + checkBoxCript.Text + "', '" + txtBoxCP.Text + "', '" + txtBoxPub.Text + "'  )", mConn);        
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
                    MessageBox.Show("Este CNPJ ja esta cadastrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtBoxRaz_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            procurarpj();
        }
        private void procurarpj()
        {
            try
            {

                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM usuclipj WHERE cnpj = '" + txtBoxCNPJ.Text.Trim() + "';", mConn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtBoxCNPJ.Text = reader.GetString("cnpj");
                    txtBoxNome.Text = reader.GetString("nome");
                    doUpSexo.Text = reader.GetString("sexo");
                    txtBoxRaz.Text = reader.GetString("razsoc");
                    txtBoxEnde.Text = reader.GetString("endereco");
                    txtBoxNEnde.Text = reader.GetString("nendereco");
                    txtBoxCEP.Text = reader.GetString("cependereco");
                    txtBoxTel.Text = reader.GetString("tele");
                    txtBoxNF.Text = reader.GetString("nfantasia");
                    txtBoxEmail.Text = reader.GetString("email");
                    txtBoxWsite.Text = reader.GetString("wsite");
                    checkBoxCript.Text = reader.GetString("criptomoeda");
                    txtBoxCP.Text = reader.GetString("cprivada");
                    txtBoxPub.Text = reader.GetString("cpublica");
                    mConn.Close();

                }
            }
            catch (Exception)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           LimpaCampos ui = new LimpaCampos();
            ui.limpa(this);           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();

                MySqlCommand command = new MySqlCommand("update usuclipj set nome = '" + txtBoxNome.Text.Trim() + "', sexo = '" + doUpSexo.Text.Trim() + "', razsoc = '" + txtBoxRaz.Text.Trim() + "', endereco = '" + txtBoxEnde.Text.Trim() + "', nendereco = '" + txtBoxNEnde.Text.Trim() + "', cependereco = '" + txtBoxCEP.Text.Trim() + "', tele = '" + txtBoxTel.Text.Trim() + "', nfantasia = '" + txtBoxNF.Text.Trim() + "', email = '" + txtBoxEmail.Text.Trim() + "', wsite = '" + txtBoxWsite.Text.Trim() + "', criptomoeda = '" + checkBoxCript.Text.Trim() + "',  cprivada = '" + txtBoxCP.Text.Trim() + "', cpublica = '" + txtBoxPub.Text.Trim() + "' where cnpj = '" + txtBoxCNPJ.Text.Trim() + "' ;", mConn);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                mConn = new MySqlConnection("server=localhost;database=omega;uid=root;password=12345");
                mConn.Open();

                MySqlCommand command = new MySqlCommand("delete from usuclipj where cnpj= '" + txtBoxCNPJ.Text.Trim() + "';", mConn);
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

        private void txtBoxCNPJ_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void txtBoxCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}

