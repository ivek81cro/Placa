using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Projekt_Placa
{
    public partial class Tvrtka : Form
    {
        public Tvrtka()
        {
            InitializeComponent();
            popuniGradCombo();
            popunilistu();
        }
        void popuniGradCombo()
        {
            comboGrad.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.gradovi;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziIme = citaj.GetString("grad");
                    comboGrad.Items.Add(traziIme);
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void popunilistu()
        {
            DataTable dbdataset;
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "SELECT idFirme AS 'Redni br.', naziv AS 'Naziv', mjesto AS 'Mjesto'" +
                ",ulica AS 'Ulica', broj AS 'Kucni br.', email AS 'OIB', IBAN AS 'IBAN', banka AS 'Banka'," +
                "OIB AS 'E-mail' FROM database.firma;";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = bazazapovjed;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);

                bazaspoj.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void btnUnosPodataka_Click(object sender, EventArgs e)
        {
            if (txtNaziv.Text != "" && txtMjesto.Text != "" && txtUlica.Text != "" && txtBroj.Text != "" &&
                maskedOIB.Text != "" && txtOznaka.Text != "")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "insert into database.firma (naziv, mjesto, ulica, broj, email, IBAN, banka, OIB, oznaka, sifra_joppd) values('" +
                               txtNaziv.Text + "','" + txtMjesto.Text + "','" + txtUlica.Text + "','" + txtBroj.Text + "','" +
                               maskedOIB.Text + "','" + txtIBAN.Text + "','" + txtBanka.Text + "','" + txtEmail.Text + "','" + 
                               txtOznaka.Text + "','" + txtSifraJoppd.Text + "');";
                MySqlConnection bazaspoj = new MySqlConnection(constring);
                MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
                MySqlDataReader citaj;
                try
                {
                    bazaspoj.Open();
                    citaj = bazazapovjed.ExecuteReader();
                    MessageBox.Show("Novi zapis spremljen.");
                    while (citaj.Read())
                    {

                    }
                    bazaspoj.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                popunilistu();
                string adresa = txtMjesto.Text + " " + txtUlica.Text + " " + txtBroj.Text;
                upit = "insert into database.joppda ( iii_1, iii_2, iii_3, iii_4, iii_5 ) values ('" + txtNaziv.Text + "','" +
                       adresa + "','" + txtEmail.Text + "','" + maskedOIB.Text + "','" + txtOznaka.Text + "' );" +
                       "update database.firma join database.joppda on firma.naziv=joppda.iii_1 set joppda.id=firma.idFirme;";
                bazaspoj = new MySqlConnection(constring);
                bazazapovjed = new MySqlCommand(upit, bazaspoj);
                try
                {
                    bazaspoj.Open();
                    citaj = bazazapovjed.ExecuteReader();
                    while (citaj.Read())
                    {

                    }
                    bazaspoj.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Provjerite dali ste popunili sve podatke.");
            }
        }
        
        private void comboGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select * from database.gradovi where grad='" + comboGrad.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                while (citaj.Read())
                {
                    string traziGrad = citaj.GetString("grad");
                    string sifraJoppd = citaj.GetString("sifra_joppd");
                    txtMjesto.Text = traziGrad;
                    txtSifraJoppd.Text = sifraJoppd;
                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "delete from database.firma where naziv='" + txtNaziv.Text + "';" +
                          "delete from database.joppda where iii_1='" + txtNaziv.Text + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                MessageBox.Show("Zapis je izbrisan.");
                while (citaj.Read())
                {

                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            popunilistu();
        }

        private void btnIzmjena_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "update database.firma set naziv='" + txtNaziv.Text + "', mjesto='" + txtMjesto.Text + "', ulica='" + txtUlica.Text +
                            "',broj='" + txtBroj.Text + "',email='" + maskedOIB.Text + "',IBAN='" + txtIBAN.Text +
                            "',banka='" + txtBanka.Text + "',OIB='" + txtEmail.Text + "',oznaka='" + txtOznaka.Text + "', sifra_joppd='" +
                            txtSifraJoppd.Text + "' where idFirme='" +  "1" + "';";
            MySqlConnection bazaspoj = new MySqlConnection(constring);
            MySqlCommand bazazapovjed = new MySqlCommand(upit, bazaspoj);
            MySqlDataReader citaj;
            try
            {
                bazaspoj.Open();
                citaj = bazazapovjed.ExecuteReader();
                MessageBox.Show("Postoječi zapis promjenjen.");
                while (citaj.Read())
                {

                }
                bazaspoj.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow red = this.dataGridView1.Rows[e.RowIndex];

                txtNaziv.Text = red.Cells["Naziv"].Value.ToString();
                txtMjesto.Text = red.Cells["Mjesto"].Value.ToString();
                txtUlica.Text = red.Cells["Ulica"].Value.ToString();
                txtBroj.Text = red.Cells["Kucni br."].Value.ToString();
                txtBanka.Text = red.Cells["Banka"].Value.ToString();
                txtIBAN.Text = red.Cells["IBAN"].Value.ToString();
                txtEmail.Text = red.Cells["E-mail"].Value.ToString();

            }
        }
    }
}
