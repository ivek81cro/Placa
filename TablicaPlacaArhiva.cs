using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projekt_Placa
{
    public partial class TablicaPlacaArhiva : Form
    {
        public TablicaPlacaArhiva()
        {
            InitializeComponent();
        }        
        private MySqlConnection connection;

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        void popuniComboboxKor()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select distinct ime_prezime from database.placa_arhiva;";
            MySqlConnection veza = new MySqlConnection(constring);
            MySqlCommand naredba = new MySqlCommand(upit, veza);
            MySqlDataReader citac;
            txtKorisnik.Items.Clear();
            txtKorisnik.Text = "Svi";
            txtKorisnik.Items.Add("Svi");

            try
            {
                veza.Open();
                citac = naredba.ExecuteReader();
                while (citac.Read())
                {
                    string korisnici = citac.GetString("ime_prezime");
                    txtKorisnik.Items.Add(korisnici);
                }
                veza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuniComboboxMj()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select distinct mjesec from database.placa_arhiva;";
            MySqlConnection veza = new MySqlConnection(constring);
            MySqlCommand naredba = new MySqlCommand(upit, veza);
            MySqlDataReader citac;
            txtMjesec.Items.Clear();
            txtMjesec.Text = "Svi";
            txtMjesec.Items.Add("Svi");

            try
            {
                veza.Open();
                citac = naredba.ExecuteReader();
                while (citac.Read())
                {
                    string mjesec = citac.GetString("mjesec");
                    txtMjesec.Items.Add(mjesec);
                }
                veza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popuniComboboxGod()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select distinct godina from database.placa_arhiva;";
            MySqlConnection veza = new MySqlConnection(constring);
            MySqlCommand naredba = new MySqlCommand(upit, veza);
            MySqlDataReader citac;
            txtGodina.Items.Clear();
            txtGodina.Text = "Sve";
            txtGodina.Items.Add("Sve");

            try
            {
                veza.Open();
                citac = naredba.ExecuteReader();
                while (citac.Read())
                {
                    string godina = citac.GetString("godina");
                    txtGodina.Items.Add(godina);
                }
                veza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private MySqlDataAdapter mySqlDataAdapter;
        private void tPlacaArhiva_Load(object sender, EventArgs e)
        {
            popuniComboboxKor();
            popuniComboboxMj();
            popuniComboboxGod();
            
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

            if (changes != null)
            {
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                mySqlDataAdapter.Update(changes);
                ((DataTable)dataGridView1.DataSource).AcceptChanges();

            }
        }
        private void txtKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=pass123";
            connection = new MySqlConnection(connectionString);

            if (this.OpenConnection() == true && txtKorisnik.Text != "")
            {
                string upit = "";
                if (txtKorisnik.Text != "Svi" && txtMjesec.Text == "Svi" && txtGodina.Text == "Sve")
                {
                    upit = "select * from database.placa_arhiva where ime_prezime='" + txtKorisnik.Text + "';";
                }
                else if (txtKorisnik.Text == "Svi" && txtMjesec.Text != "Svi" && txtGodina.Text == "Sve")
                {
                    upit = "select * from database.placa_arhiva where mjesec='" + txtMjesec.Text + "';";
                }
                else if (txtKorisnik.Text == "Svi" && txtMjesec.Text == "Svi" && txtGodina.Text != "Sve")
                {
                    upit = "select * from database.placa_arhiva where godina='" + txtGodina.Text + "';";
                }
                else if (txtKorisnik.Text != "Svi" && txtMjesec.Text != "Svi" && txtGodina.Text == "Sve")
                {
                    upit = "select * from database.placa_arhiva where ime_prezime='" + txtKorisnik.Text + "' and mjesec='" + txtMjesec.Text + "';";
                }
                else if (txtKorisnik.Text != "Svi" && txtMjesec.Text == "Svi" && txtGodina.Text != "Sve")
                {
                    upit = "select * from database.placa_arhiva where ime_prezime='" + txtKorisnik.Text + "' and godina='" + txtGodina.Text + "';";
                }
                else if (txtKorisnik.Text != "Svi" && txtMjesec.Text != "Svi" && txtGodina.Text != "Sve")
                {
                    upit = "select * from database.placa_arhiva where ime_prezime='" + txtKorisnik.Text + "' and godina='" + txtGodina.Text + "' and mjesec='" + txtMjesec.Text + "';";
                }
                else
                {
                    upit = "select * from database.placa_arhiva;";
                }
                mySqlDataAdapter = new MySqlDataAdapter(upit, connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                //close connection
                this.CloseConnection();
                dataGridView1.Columns["zapis_br"].Visible = false;
                dataGridView1.Columns["idDjelatnika"].Visible = false;
            }
            else
            {
                MessageBox.Show("Molim odaberite djelatnika.");
            }
        }
    }
}
