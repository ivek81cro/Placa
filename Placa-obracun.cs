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
using System.Globalization;
using System.Diagnostics;

namespace Projekt_Placa
{
    public partial class Placa_obracun : Form
    {
        public Placa_obracun()
        {
            InitializeComponent();
            LoadDatagrid();
            popuniComboboxMjeseci();
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            string mjesec = dt.ToString("MM");
            string godina = dt.ToString("yyyy");
            // Prvo slovo capitalize
            char[] array = mjesec.ToCharArray();
            // Pregled prvog slova u stringu.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            txtMjesec.Text = mjesec;
            txtGodina.Text = godina;

            dateOd.CustomFormat = "dd.MM.yyyy";
            dateOd.Format = DateTimePickerFormat.Custom;
            if (dateOd.Value.Month != 1)
            {
                dateOd.Value = new DateTime(dateOd.Value.Year, dateOd.Value.Month - 1, 1);
            }
            else
            {
                dateOd.Value = new DateTime(dateOd.Value.Year - 1, dateOd.Value.Month + 11, 1);
            }
            // Izrada zadnjeg dana u mjesecu, lakši način--------------------------
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var last = month.AddDays(-1);
            dateDo.CustomFormat = "dd.MM.yyyy";
            dateDo.Text = last.ToString("dd.MM.yyyy");
            // -------------------------------------------------------------
            dateObracuna.CustomFormat = "dd.MM.yyyy";
            dateObracuna.Format = DateTimePickerFormat.Custom;
            dateIsplate.CustomFormat = "dd.MM.yyyy";
            dateIsplate.Format = DateTimePickerFormat.Custom;
        }
        DataTable dbdataset;
        void LoadDatagrid()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            MySqlConnection connection = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select idDjelatnika as 'Broj', ime_prezime as 'Ime_i_prezime', bruto as 'Bruto'" +
                    ", mio1 as 'MIO_1', mio2 as 'MIO_2', odbitak as 'Odbitak', porez12 as 'Porez_12%', porez25 as 'Porez_25%', porez40 as 'Porez_40%', prirez as 'Prirez'" + 
                    ", neto as 'Netto', prijevoz as 'Prijevoz', zaisplatu as 'Isplata', dopzdravstveno as 'Zdravsveno', dopzastita as'Zaš_na_radu'" +
                    ", dopzaposljavanje as 'Dop_zapoš.' from database.placa ;", connection);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            void LoadPoMjesecu()
            {
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                MySqlConnection connection = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select idDjelatnika as 'Broj', sati as 'Sati', ime_prezime as 'Ime_i_prezime', bruto as 'Bruto'" +
                    ", mio1 as 'MIO_1', mio2 as 'MIO_2', odbitak as 'Odbitak', porez12 as 'Porez_12%', porez25 as 'Porez_25%', porez40 as 'Porez_40%', prirez as 'Prirez'" + 
                    ", neto as 'Netto', prijevoz as 'Prijevoz', zaisplatu as 'Isplata', dopzdravstveno as 'Zdravsveno', dopzastita as'Zaš_na_radu'" +
                    ", dopzaposljavanje as 'Dop_zapoš.', obr_od as 'Obračun_od', obr_do as 'Obračun_do', dat_obr as 'Datum_obr', danisplate as 'Dospjeće'" +
                    " from database.placa_arhiva where mjesec='" + txtOtvoriMjesec.Text + "' and godina='" + txtArhivaGodina.Text + "' ;", connection);
                        
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            void popuniComboboxMjeseci()
            {
                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "select distinct mjesec from database.placa_arhiva where bruto !='0';";
                MySqlConnection veza = new MySqlConnection(constring);
                MySqlCommand naredba = new MySqlCommand(upit, veza);
                MySqlDataReader citac;

                try
                {
                    veza.Open();
                    citac = naredba.ExecuteReader();
                    string arhMjeseciProvjera = "0";
                    while (citac.Read())
                    {
                        string arhMjeseci = citac.GetString("mjesec");
                        if (arhMjeseciProvjera != arhMjeseci)
                        {
                            txtOtvoriMjesec.Items.Add(arhMjeseci);
                        }
                        arhMjeseciProvjera = arhMjeseci;
                        
                    }
                    veza.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtOtvoriMjesec.Sorted = true;
            }

            private void txtOtvoriMjesec_SelectedIndexChanged(object sender, EventArgs e)
            {
            txtArhivaGodina.Items.Clear();
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "select distinct obr_do from database.placa_arhiva where bruto !='0' and sati !='0' and mjesec='" + txtOtvoriMjesec.Text + "';";
            MySqlConnection veza = new MySqlConnection(constring);
            MySqlCommand naredba = new MySqlCommand(upit, veza);
            MySqlDataReader citac;

            try
            {
                veza.Open();
                citac = naredba.ExecuteReader();
                string arhGodinaProvjera = "0";
                while (citac.Read())
                {
                    string arhGodina1 = citac.GetString("obr_do");
                    string arhGodina = arhGodina1.Substring(arhGodina1.Length - 4, 4);
                    if (arhGodinaProvjera != arhGodina)
                    {
                        txtArhivaGodina.Items.Add(arhGodina);
                    }
                    arhGodinaProvjera = arhGodina;
                }
                veza.Close();
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtArhivaGodina.Sorted = true;
            }

        private void btnArhiviraj_Click(object sender, EventArgs e)
        {
            if (txtRadnihSatiDefault.Text != "")
            {
                int godinaIzmjeneBroj = Convert.ToInt16(txtGodina.Text);
                if (txtMjesec.Text == "12")
                {
                    godinaIzmjeneBroj = godinaIzmjeneBroj + 1;
                }
                string godinaIzmjene = godinaIzmjeneBroj.ToString();

                string constring = "datasource=localhost;port=3306;username=root;password=pass123";
                string upit = "update database.placa_arhiva pa, database.placa pl set pa.bruto=pl.bruto, pa.mio1=pl.mio1, pa.mio2=pl.mio2, " +
                          "pa.odbitak=pl.odbitak, pa.porez12=pl.porez12, pa.porez25=pl.porez25, pa.porez40=pl.porez40, pa.prirez=pl.prirez, pa.neto=pl.neto, " +
                          "pa.prijevoz=pl.prijevoz, pa.zaisplatu=pl.zaisplatu, pa.dopzdravstveno=pl.dopzdravstveno, pa.dopzastita=pl.dopzastita, " +
                          "pa.dopzaposljavanje=pl.dopzaposljavanje, pa.trosakposlodavac=pl.trosakposlodavac, pa.mioukupno=pl.mioukupno, " +
                          "pa.dohodak=pl.dohodak, pa.porosn=pl.porosn, pa.porezukupno=pl.porezukupno, pa.podplaca=pl.podplaca, pa.ukupnonaplacu=pl.ukupnonaplacu" +
                          " where pa.idDjelatnika=pl.idDjelatnika and pa.mjesec='" + txtMjesec.Text + "' and pa.godina='" + godinaIzmjene + "';" +
                          "update database.placa_arhiva set obr_od='" + dateOd.Text + "', obr_do='" + dateDo.Text + "', dat_obr='" + dateObracuna.Text +
                          "', danisplate='" + dateIsplate.Text + "', sati='" + txtRadnihSatiDefault.Text + "' where mjesec='" + txtMjesec.Text + "' and godina='" + godinaIzmjene + "' ;";

                MySqlConnection veza = new MySqlConnection(constring);
                MySqlCommand naredba = new MySqlCommand(upit, veza);
                MySqlDataReader citac;

                try
                {
                    veza.Open();
                    citac = naredba.ExecuteReader();
                    while (citac.Read())
                    {

                    }
                    MessageBox.Show("Postojeći zapis je arhiviran.");
                    veza.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Unesite fond radnih sati.");
            }
        }   

        private void btnOtvori_Click(object sender, EventArgs e)
        {
            if (txtOtvoriMjesec.Text != "" && txtArhivaGodina.Text != "")
            {
                LoadPoMjesecu();
                txtRadnihSatiDefault.Text = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value);
                dateOd.Text = Convert.ToString(dataGridView1.Rows[0].Cells[17].Value);
                dateDo.Text = Convert.ToString(dataGridView1.Rows[0].Cells[18].Value);
                dateObracuna.Text = Convert.ToString(dataGridView1.Rows[0].Cells[19].Value);
                dateIsplate.Text = Convert.ToString(dataGridView1.Rows[0].Cells[20].Value);
                txtGodina.Text = txtArhivaGodina.Text;
                txtMjesec.Text = txtOtvoriMjesec.Text;

                double bruto = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bruto += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value, CultureInfo.InvariantCulture);
                }
                txtBruto.Text = bruto.ToString("N");

                double mio1 = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    mio1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value, CultureInfo.InvariantCulture);
                }
                txtMio.Text = mio1.ToString("N");

                double mio2 = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    mio2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value, CultureInfo.InvariantCulture);
                }
                txtMio2.Text = mio2.ToString("N");

                double odbitak = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    odbitak += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value, CultureInfo.InvariantCulture);
                }
                txtOdbitak.Text = odbitak.ToString("N");

                double porez12 = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    porez12 += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value, CultureInfo.InvariantCulture);
                }
                txtPorez12.Text = porez12.ToString("N");

                double porez25 = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    porez25 += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value, CultureInfo.InvariantCulture);
                }
                txtPorez25.Text = porez25.ToString("N");

                double porez40 = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    porez40 += Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value, CultureInfo.InvariantCulture);
                }
                txtPorez40.Text = porez40.ToString("N");

                double prirez = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    prirez += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value, CultureInfo.InvariantCulture);
                }
                txtPrirez.Text = prirez.ToString("N");

                double neto = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    neto += Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value, CultureInfo.InvariantCulture);
                }
                txtNeto.Text = neto.ToString("N");

                double prijevoz = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    prijevoz += Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value, CultureInfo.InvariantCulture);
                }
                txtPrijevoz.Text = prijevoz.ToString("N");

                double isplata = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    isplata += Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value, CultureInfo.InvariantCulture);
                }
                txtIsplata.Text = isplata.ToString("N");

                double zdravstveno = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    zdravstveno += Convert.ToDouble(dataGridView1.Rows[i].Cells[14].Value, CultureInfo.InvariantCulture);
                }
                txtZdravstveno.Text = zdravstveno.ToString("N");

                double zastita = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    zastita += Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value, CultureInfo.InvariantCulture);
                }
                txtZastita.Text = zastita.ToString("N");

                double zaposljavanje = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    zaposljavanje += Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value, CultureInfo.InvariantCulture);
                }
                txtZaposljavanje.Text = zaposljavanje.ToString("N");
            }
            else
            {
                MessageBox.Show("Odaberite mjesec i godinu za plaću iz arhive.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = "UPDATE database.placa_arhiva SET mjesec='" + txtMjesec.Text + "', obr_od='" + dateOd.Text + "', obr_do='" + dateDo.Text +
                          "', dat_obr='" + dateObracuna.Text + "', danisplate='" + dateIsplate.Text + "', sati='" + txtRadnihSatiDefault.Text + 
                          "' WHERE mjesec='" + txtMjesec.Text + "' AND obr_do LIKE '%." + txtGodina.Text + "';";

            MySqlConnection veza = new MySqlConnection(constring);
            MySqlCommand naredba = new MySqlCommand(upit, veza);
            MySqlDataReader citac;

            try
            {
                veza.Open();
                citac = naredba.ExecuteReader();
                while (citac.Read())
                {

                }
                MessageBox.Show("Postojeći zapis je izmjenjen.");
                veza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRadnihSatiDefault_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.google.hr/?gfe_rd=cr&ei=TlMTVevMK-aH8QfKsYBY&gws_rd=ssl#q=fond+radinh+sati");
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=pass123";
            string upit = " update database.placa_arhiva set bruto='0', mio1='0', mio2='0', odbitak='0', porez12='0', porez25='0', porez40='0', prirez='0'," +
                          " neto='0', prijevoz='0', zaisplatu='0', dopzdravstveno='0', dopzastita='0', dopzaposljavanje='0', trosakposlodavac='0'," +
                          " mioukupno='0', dohodak='0', porosn='0', porezukupno='0', podplaca='0', ukupnonaplacu='0', obr_od='01.01.2000'," +
                          " obr_do='01.01.2000', dat_obr='01.01.2000', sati='0' WHERE mjesec='" + txtOtvoriMjesec.Text +
                          "' and obr_do LIKE'%" + txtArhivaGodina.Text + "'";

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
    }  
}
